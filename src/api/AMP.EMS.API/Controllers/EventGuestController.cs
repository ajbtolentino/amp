using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AMP.EMS.API.Controllers.EventInvitationController;
using static AMP.EMS.API.Controllers.EventRoleController;
using static AMP.EMS.API.Controllers.GuestController;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuest, Guid>(unitOfWork)
    {
        public record EventGuestData(GuestData? Guest, Guid EventId, Guid? GuestId, int? MaxGuests, IEnumerable<Guid>? EventRoleIds, IEnumerable<Guid>? EventInvitationIds);

        public override async Task<IActionResult> Get(Guid id)
        {
            var entity = await this.entityRepository.GetAll()
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Guest)
                                    .Include(_ => _.EventGuestInvitations)
                                        .ThenInclude(_ => _.EventInvitation)
                                    .Include(_ => _.EventGuestInvitations)
                                        .ThenInclude(_ => _.EventGuestInvitationRSVPs)
                                        .ThenInclude(_ => _.EventGuestInvitationRSVPItems)
                                    .Include(_ => _.EventGuestRoles)
                                        .ThenInclude(_ => _.EventRole)
                                    .FirstOrDefaultAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = entity });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestData request)
        {
            try
            {
                if (request.GuestId.HasValue)
                {
                    return await base.Post(new EventGuest
                    {
                        EventId = request.EventId,
                        GuestId = request.GuestId.Value,
                        MaxGuests = request.MaxGuests ?? 0
                    });
                }

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

                    this.UpdateEventGuestInvitations(newEventGuest, request.EventInvitationIds ?? []);

                    this.UpdateEventGuestRoles(newEventGuest, request.EventRoleIds ?? []);

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

        private string GenerateCode()
        {
            var rand = new Random();

            // Choosing the size of string 
            // Using Next() string 
            var stringlen = rand.Next(4, 10);
            var randValue = 0;
            var str = string.Empty;
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number. 
                randValue = rand.Next(0, 26);

                // Generating random character by converting 
                // the random number into character. 
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string. 
                str += letter;
            }

            return str;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestData request)
        {
            try
            {
                var entity = await this.entityRepository.Get(id);

                if (entity == null) return BadRequest();

                if (request.Guest == null && (request.EventId != entity.EventId || request.GuestId != entity.GuestId))
                {
                    entity.EventId = request.EventId;
                    entity.GuestId = request.GuestId.Value;

                    return await base.Put(entity);
                }

                if (request.Guest != null && request.GuestId.HasValue)
                {
                    this.unitOfWork.BeginTransaction();

                    var guest = await this.unitOfWork.Repository<Guest>().Get(request.GuestId);

                    guest.FirstName = request.Guest.FirstName;
                    guest.LastName = request.Guest.LastName;
                    guest.NickName = request.Guest.Nickname ?? string.Empty;
                    guest.PhoneNumber = request.Guest.PhoneNumber ?? string.Empty;

                    this.unitOfWork.Repository<Guest>().Update(guest);

                    var eventGuest = await this.entityRepository.Get(id);

                    eventGuest.MaxGuests = request.MaxGuests ?? 0;

                    this.UpdateEventGuestInvitations(eventGuest, request.EventInvitationIds ?? []);
                    this.UpdateEventGuestRoles(eventGuest, request.EventRoleIds ?? []);

                    this.entityRepository.Update(eventGuest);

                    await this.unitOfWork.SaveChangesAsync();
                    await this.unitOfWork.CommitTransactionAsync();

                    entity = await this.entityRepository.GetAll()
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Guest)
                                    .FirstOrDefaultAsync();

                    return Ok(new OkResponse<EventGuest>(string.Empty) { Data = entity });
                }
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }

        private void UpdateEventGuestInvitations(EventGuest eventGuest, IEnumerable<Guid> eventInvitationIds)
        {
            var eventGuestInvitations = this.unitOfWork.Repository<EventGuestInvitation>().GetAll().AsNoTracking().Where(_ => _.EventGuestId == eventGuest.Id);
            var newEventInvitationIds = eventInvitationIds.Except(eventGuestInvitations.Select(_ => _.EventInvitationId));
            var deletedEventGuestInvitations = eventGuestInvitations.Where(_ => !eventInvitationIds.Contains(_.EventInvitationId));

            foreach (var eventInvitationId in newEventInvitationIds)
            {
                this.unitOfWork.Repository<EventGuestInvitation>().Add(new EventGuestInvitation
                {
                    Code = GenerateCode(),
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
            var eventGuestRoles = this.unitOfWork.Repository<EventGuestRole>().GetAll().AsNoTracking().Where(_ => _.EventGuestId == eventGuest.Id);
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
