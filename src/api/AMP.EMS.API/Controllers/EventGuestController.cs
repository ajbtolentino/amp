using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
using AMP.EMS.API.Models;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuest, Guid>(unitOfWork)
    {
        public record EventGuestData(
            Guid EventId,
            Guid? GuestId,
            int? MaxGuests,
            IEnumerable<Guid>? EventGuestRoles,
            IEnumerable<Guid>? EventInvitations);
        public record EventGuestRequest(GuestController.GuestData? Guest, EventGuestData EventGuest);
        public record EventGuestResponse(EventGuest EventGuest, Guest Guest);
        
        public override async Task<IActionResult> Get(Guid id)
        {
            var eventGuest = await this.entityRepository.GetAll().FirstOrDefaultAsync(_ => _.Id == id);
            
            ArgumentNullException.ThrowIfNull(eventGuest);
            
            var guest = await unitOfWork.Repository<Guest>().Get(eventGuest.GuestId);
            
            ArgumentNullException.ThrowIfNull(guest);

            return Ok(new OkResponse<EventGuestResponse>(string.Empty) { Data = new EventGuestResponse(eventGuest, guest) });
        }

        [HttpGet]
        [Route("{id:guid}/invitations")]
        public async Task<IActionResult> GetInvitations(Guid id)
        {
            var eventGuest = this.entityRepository.GetAll()
                                        .Where(_ => _.Id == id)
                                        .Include(_ => _.EventGuestInvitations)
                                            .ThenInclude(_ => _.EventGuestInvitationRsvps)
                                            .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
                                        .FirstOrDefault();
            
            ArgumentNullException.ThrowIfNull(eventGuest);
                
            return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuest.EventGuestInvitations });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestRequest request)
        {
            try
            {
                if (request.Guest != null)
                {
                    this.unitOfWork.BeginTransaction();

                    var newGuest = await this.unitOfWork.Repository<Guest>().Add(new Guest
                    {
                        FirstName = request.Guest.FirstName,
                        LastName = request.Guest.LastName,
                        NickName = request.Guest.Nickname ?? string.Empty,
                        PhoneNumber = request.Guest.PhoneNumber ?? string.Empty
                    });

                    var newEventGuest = await this.entityRepository.Add(new EventGuest
                    {
                        EventId = request.EventGuest.EventId,
                        GuestId = newGuest.Id,
                        MaxGuests = request.EventGuest.MaxGuests ?? 0
                    });

                    await UpdateEventGuestInvitations(newEventGuest, request.EventGuest.EventInvitations ?? []);

                    UpdateEventGuestRoles(newEventGuest, request.EventGuest.EventGuestRoles ?? []);

                    await this.unitOfWork.SaveChangesAsync();
                    await this.unitOfWork.CommitTransactionAsync();

                    return Ok(new OkResponse<EventGuest>(string.Empty) { Data = newEventGuest });
                }
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestRequest request)
        {
            try
            {
                var eventGuest = await this.entityRepository.Get(id);

                ArgumentNullException.ThrowIfNull(eventGuest);

                this.unitOfWork.BeginTransaction();

                var guest = await this.unitOfWork.Repository<Guest>().Get(eventGuest.GuestId);
                
                ArgumentNullException.ThrowIfNull(guest);

                guest.FirstName = request.Guest.FirstName;
                guest.LastName = request.Guest.LastName;
                guest.NickName = request.Guest.Nickname ?? string.Empty;
                guest.PhoneNumber = request.Guest.PhoneNumber ?? string.Empty;

                this.unitOfWork.Repository<Guest>().Update(guest);

                eventGuest.MaxGuests = request.EventGuest.MaxGuests ?? 0;

                await UpdateEventGuestInvitations(eventGuest, request.EventGuest.EventInvitations ?? []);
                UpdateEventGuestRoles(eventGuest, request.EventGuest.EventGuestRoles ?? []);

                this.entityRepository.Update(eventGuest);

                await this.unitOfWork.SaveChangesAsync();
                await this.unitOfWork.CommitTransactionAsync();

                eventGuest = await this.entityRepository.GetAll()
                                .Where(_ => _.Id == id)
                                .FirstOrDefaultAsync();

                return Ok(new OkResponse<EventGuest>(string.Empty) { Data = eventGuest });
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }

        private async Task UpdateEventGuestInvitations(EventGuest eventGuest, IEnumerable<Guid> eventInvitationIds)
        {
            // eventGuest.EventInvitations = [];
            //
            // var existingEventInvitations = await unitOfWork.Repository<EventGuestInvitation>()
            //     .GetAll().AsNoTracking().Where(eventGuestInvitation =>
            //         eventGuest.EventGuestInvitations.Contains(eventGuestInvitation.Id))
            //     .Select(eventGuestInvitation => eventGuestInvitation.EventInvitationId)
            //     .ToListAsync();
            //
            // var newEventInvitationIds = eventInvitationIds.Except(existingEventInvitations);
            //
            // foreach (var eventInvitationId in newEventInvitationIds)
            // {
            //     var eventGuestInvitation = await this.unitOfWork.Repository<EventGuestInvitation>().Add(new EventGuestInvitation
            //     {
            //         Code = InvitationHelper.GenerateCode(),
            //         EventInvitationId = eventInvitationId,
            //         MaxGuests = eventGuest.MaxGuests
            //     });
            //     
            //     eventGuest.EventGuestInvitations.Add(eventGuestInvitation.Id);    
            // }
            //
            // eventGuest.EventInvitations = eventInvitationIds.ToList();
        }

        private static void UpdateEventGuestRoles(EventGuest eventGuest, IEnumerable<Guid> eventRoleIds)
        {
            // eventGuest.EventGuestRoles = eventRoleIds.ToList();
        }
    }
}
