using System.Collections;
using System.Net.Http.Headers;
using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Models;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IUnitOfWork unitOfWork) : ApiBaseController<Event, Guid>(unitOfWork)
    {
        public record EventRequest(string Title, Guid EventTypeId, string? Description, string? Location, int MaxGuests, DateTime StartDate, DateTime EndDate);

        [HttpGet]
        [Route("{eventId:guid}/roles")]
        public IActionResult GetRoles(Guid eventId)
        {
            var eventGuestRoles = base.unitOfWork.Repository<EventGuestRole>().GetAll().Where(role => role.EventId == eventId).AsNoTracking();

            return Ok(new OkResponse<IEnumerable<EventGuestRole>>(string.Empty) { Data = eventGuestRoles });
        }

        [HttpGet]
        [Route("{eventId:guid}/guests")]
        public async Task<IActionResult> GetGuests(Guid eventId)
        {
            var eventGuests = await this.unitOfWork.Repository<EventGuest>().GetAll().Where(eventGuest => eventGuest.EventId == eventId)
                .AsNoTracking().ToListAsync();

            var eventGuestRoles =
                await unitOfWork.Repository<EventGuestRole>().GetAll().Where(eventGuestRole => eventGuestRole.EventId == eventId).ToListAsync();

            var model = MapEventGuestModel(eventGuests, eventGuestRoles);

            return Ok(new OkResponse<IAsyncEnumerable<EventGuestModel>>(string.Empty) { Data = model });
        }
        
        [HttpGet]
        [Route("{eventId:guid}/invitations")]
        public async Task<IActionResult> GetInvitations(Guid eventId)
        {
            var eventGuests = await unitOfWork.Repository<EventGuest>()
                .GetAll().AsNoTracking()
                .Where(eventGuest => eventGuest.EventId == eventId).ToListAsync();

            var eventInvitationIds = eventGuests.SelectMany(eventGuest => eventGuest.EventInvitations);
            var eventGuestInvitationIds = eventGuests.SelectMany(eventGuest => eventGuest.EventGuestInvitations);
            
            var eventInvitations = await unitOfWork.Repository<EventInvitation>()
                                .GetAll().AsNoTracking()
                                .Where(eventInvitation => eventInvitation.EventId == eventId).ToListAsync();

            var eventGuestInvitations = await unitOfWork.Repository<EventGuestInvitation>().GetAll().AsNoTracking()
                .Where(eventGuestInvitation => eventInvitationIds.Contains(eventGuestInvitation.EventInvitationId) && 
                                               eventGuestInvitationIds.Contains(eventGuestInvitation.Id)).ToListAsync();

            var eventGuestInvitationRsvpIds = eventGuestInvitations.SelectMany(e => e.EventGuestInvitationRsvps);

            var eventGuestInvitationRsvps = await unitOfWork.Repository<EventGuestInvitationRsvp>().GetAll().AsNoTracking()
                .Where(eventGuestInvitationRsvp => eventGuestInvitationRsvpIds.Contains(eventGuestInvitationRsvp.Id)).ToListAsync();

            var model = eventInvitations.Select(eventInvitation => new EventInvitationModel
            {
                Name = eventInvitation.Name,
                Description = eventInvitation.Description,
                EventInvitationId = eventInvitation.Id,
                EventGuestInvitations = eventGuestInvitations.Select(eventGuestInvitation => new EventGuestInvitationModel
                {
                    EventGuestInvitationId = eventGuestInvitation.Id,
                    MaxGuests = eventGuestInvitation.MaxGuests,
                    Code=eventGuestInvitation.Code,
                    Rsvps = MapEventGuestInvitationRsvps(eventGuestInvitation, eventGuestInvitationRsvps)
                })
            });
            
            return Ok(new OkResponse<IEnumerable<EventInvitationModel>>(string.Empty) { Data = model });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventRequest request)
        {
            return await base.Post(new Event
            {
                Title = request.Title,
                EventTypeId = request.EventTypeId,
                Description = request.Description ?? string.Empty,
                Location = request.Location ?? string.Empty,
                MaxGuests = request.MaxGuests,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventRequest request)
        {
            var @event = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(@event);

            @event.Title = request.Title;
            @event.EventTypeId = request.EventTypeId;
            @event.Description = request.Description ?? string.Empty;
            @event.Location = request.Location ?? string.Empty;
            @event.MaxGuests = request.MaxGuests;
            @event.StartDate = request.StartDate;
            @event.EndDate = request.EndDate;

            return await base.Put(@event);
        }

        private async IAsyncEnumerable<EventGuestModel> MapEventGuestModel(IEnumerable<EventGuest> eventGuests,
            IEnumerable<EventGuestRole> eventGuestRoles)
        {
            var guests = await unitOfWork.Repository<Guest>()
                .GetAll().AsNoTracking()
                .Where(guest => eventGuests.Any(eventGuest => eventGuest.GuestId == guest.Id)).ToListAsync();

            var eventInvitationIds = eventGuests.SelectMany(eventGuest => eventGuest.EventInvitations);
            var eventGuestInvitationIds = eventGuests.SelectMany(eventGuest => eventGuest.EventGuestInvitations);
            
            var eventGuestInvitations = await unitOfWork.Repository<EventGuestInvitation>().GetAll()
                .Where(eventGuestInvitation => eventInvitationIds.Contains(eventGuestInvitation.EventInvitationId)).ToListAsync();

            var eventGuestInvitationRsvpIds = eventGuestInvitations.SelectMany(rsvp => rsvp.EventGuestInvitationRsvps);
            
            var eventGuestInvitationRsvps = await unitOfWork.Repository<EventGuestInvitationRsvp>().GetAll()
                .Where(eventGuestInvitationRsvp => eventGuestInvitationRsvpIds.Contains(eventGuestInvitationRsvp.Id)).ToListAsync();
            
            foreach (var eventGuest in eventGuests)
            {
                var guest = guests.FirstOrDefault(guest => guest.Id == eventGuest.GuestId);
                
                yield return new EventGuestModel()
                {
                    EventId = eventGuest.EventId,
                    EventGuestId = eventGuest.Id,
                    GuestId = guest.Id,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    MaxGuests = eventGuest.MaxGuests,
                    EventGuestRoles = MapEventGuestRoleModel(eventGuest, eventGuestRoles).ToList(),
                    EventGuestInvitations = MapEventGuestInvitationModel(eventGuest, eventGuestInvitations, eventGuestInvitationRsvps)
                };
            }
        }

        private static IEnumerable<EventGuestRoleModel> MapEventGuestRoleModel(EventGuest eventGuest,
            IEnumerable<EventGuestRole> eventGuestRoles)
        {
            return eventGuestRoles.Where(eventGuestRole => eventGuest.EventGuestRoles.Contains(eventGuestRole.Id))
                .Select(eventGuestRole => new EventGuestRoleModel
                {
                    Id = eventGuestRole.Id,
                    Name = eventGuestRole.Name
                });
        }

        private static IEnumerable<EventGuestInvitationModel> MapEventGuestInvitationModel(EventGuest eventGuest,
            IEnumerable<EventGuestInvitation> eventGuestInvitations,
            IEnumerable<EventGuestInvitationRsvp> eventGuestInvitationsRsvps)
        {
            return eventGuestInvitations.Where(eventGuestInvitation =>
                    eventGuest.EventInvitations.Contains(eventGuestInvitation.EventInvitationId))
                .Select(eventGuestInvitation => new EventGuestInvitationModel
                {
                    EventGuestInvitationId = eventGuestInvitation.Id,
                    MaxGuests = eventGuestInvitation.MaxGuests,
                    Code = eventGuestInvitation.Code,
                    Rsvps = MapEventGuestInvitationRsvpModel(eventGuestInvitation, eventGuestInvitationsRsvps)
                });
        }

        private static IEnumerable<EventGuestInvitationRsvpModel> MapEventGuestInvitationRsvpModel(
            EventGuestInvitation eventGuestInvitation,
            IEnumerable<EventGuestInvitationRsvp> eventGuestInvitationRsvps)
        {
            return eventGuestInvitationRsvps
                .Select(eventGuestInvitationRsvp => new EventGuestInvitationRsvpModel
                {
                    EventGuestInvitationRsvpId = eventGuestInvitationRsvp.Id,
                    Response = eventGuestInvitationRsvp.Response,
                    DateCreated = eventGuestInvitationRsvp.DateCreated
                });
        }
        
        private static IEnumerable<EventGuestInvitationRsvpModel> MapEventGuestInvitationRsvps(EventGuestInvitation eventGuestInvitation, IEnumerable<EventGuestInvitationRsvp> eventGuestInvitationRsvps)
        {
            return eventGuestInvitationRsvps.Where(rsvp => eventGuestInvitation.EventGuestInvitationRsvps.Contains(rsvp.Id)).
                OrderByDescending(rsvp => rsvp.DateCreated).Select(eventGuestInvitationRsvp => new EventGuestInvitationRsvpModel
            {
                EventGuestInvitationRsvpId = eventGuestInvitation.Id,
                Response = eventGuestInvitationRsvp.Response,
                DateCreated = eventGuestInvitationRsvp.DateCreated,
                GuestNames = eventGuestInvitationRsvp.GuestNames
            });
        }

    }
}
