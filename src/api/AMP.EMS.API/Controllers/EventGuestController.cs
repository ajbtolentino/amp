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
        public record EventGuestRequest(GuestController.GuestData? Guest, Guid EventId, Guid? GuestId, int? MaxGuests, IEnumerable<Guid>? EventRoleIds, IEnumerable<Guid>? EventInvitationIds);
        
        public override async Task<IActionResult> Get(Guid id)
        {
            var eventGuest = await this.entityRepository.GetAll()
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Guest)
                                    .Include(_ => _.EventGuestInvitations)
                                        .ThenInclude(_ => _.EventInvitation)
                                    .Include(_ => _.EventGuestInvitations)
                                        .ThenInclude(_ => _.EventGuestInvitationRsvps)
                                        .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
                                    .Include(_ => _.EventGuestRoles)
                                        .ThenInclude(_ => _.EventRole)
                                    .FirstOrDefaultAsync();
            
            ArgumentNullException.ThrowIfNull(eventGuest);
            
            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = eventGuest });
        }

        [HttpGet]
        [Route("{id:guid}/invitations")]
        public IActionResult GetInvitations(Guid id)
        {
            var eventGuestInvitations = this.unitOfWork.Repository<EventGuestInvitation>().GetAll()
                                        .Where(_ => _.EventGuestId == id)
                                        .Include(_ => _.EventInvitation)
                                        .Include(_ => _.EventGuestInvitationRsvps)
                                            .ThenInclude(_ => _.EventGuestInvitationRsvpItems);
            
            ArgumentNullException.ThrowIfNull(eventGuestInvitations);
                
            return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
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
                        EventId = request.EventId,
                        GuestId = newGuest.Id,
                        MaxGuests = request.MaxGuests ?? 0
                    });

                    UpdateEventGuestInvitations(newEventGuest, request.EventInvitationIds ?? []);
                    UpdateEventGuestRoles(newEventGuest, request.EventInvitationIds ?? []);

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

                eventGuest.MaxGuests = request.MaxGuests ?? 0;

                UpdateEventGuestInvitations(eventGuest, request.EventInvitationIds ?? []);
                UpdateEventGuestRoles(eventGuest, request.EventRoleIds ?? []);

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

        private void UpdateEventGuestInvitations(EventGuest eventGuest, IEnumerable<Guid> eventInvitationIds)
        {
            var eventGuestInvitations = this.unitOfWork.Repository<EventGuestInvitation>().GetAll().AsNoTracking()
                .Where(_ => _.EventGuestId == eventGuest.Id);
            var newEventInvitationIds =
                eventInvitationIds.Except(eventGuestInvitations.Select(_ => _.EventInvitationId));
            var deletedEventGuestInvitations =
                eventGuestInvitations.Where(_ => !eventInvitationIds.Contains(_.EventInvitationId));

            foreach (var eventInvitationId in newEventInvitationIds)
            {
                this.unitOfWork.Repository<EventGuestInvitation>().Add(new EventGuestInvitation
                {
                    Code = InvitationHelper.GenerateCode(),
                    EventGuestId = eventGuest.Id,
                    EventInvitationId = eventInvitationId
                });
            }

            foreach (var eventGuestInvitation in deletedEventGuestInvitations)
            {
                this.unitOfWork.Repository<EventGuestInvitation>().Delete(eventGuestInvitation.Id);
            }
        }

        private void UpdateEventGuestRoles(EventGuest eventGuest, IEnumerable<Guid> eventRoleIds)
        {
            var eventGuestRoles = this.unitOfWork.Repository<EventGuestRole>().GetAll().AsNoTracking()
                .Where(_ => _.EventGuestId == eventGuest.Id);
            var newEventRoles = eventRoleIds.Except(eventGuestRoles.Select(_ => _.EventRoleId));
            var deletedEventGuestRoles = eventGuestRoles.Where(_ => !eventRoleIds.Contains(_.EventRoleId));

            foreach (var eventRoleId in newEventRoles)
            {
                this.unitOfWork.Repository<EventGuestRole>().Add(new EventGuestRole
                {
                    EventGuestId = eventGuest.Id,
                    EventRoleId = eventRoleId
                });
            }

            foreach (var eventGuestRole in deletedEventGuestRoles)
            {
                this.unitOfWork.Repository<EventGuestRole>().Delete(eventGuestRole.Id);
            }
        }
    }
}
