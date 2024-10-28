using System.Collections;
using System.Security.Claims;
using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Models;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInvitationController(IUnitOfWork unitOfWork) : ApiBaseController<EventInvitation, Guid>(unitOfWork)
    {
        public record EventInvitationData(string Name, string? Description, string? Html, Guid EventId);
        
        [HttpGet]
        [Route("{id:guid}/guests")]
        public async Task<IActionResult> GetGuests(Guid id)
        {
            var eventInvitation = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventInvitation);

            var eventGuests = await unitOfWork.Repository<EventGuest>().GetAll()
                .Where(eventGuest => eventGuest.EventInvitations.Contains(id)).ToListAsync();
            
            var eventGuestInvitations = await unitOfWork.Repository<EventGuestInvitation>().GetAll()
                .Where(eventGuestInvitation =>
                    eventGuests.Any(eventGuest => eventGuest.EventGuestInvitations.Contains(eventGuestInvitation.Id)) 
                    && eventGuestInvitation.EventInvitationId == id)
                .ToListAsync();

            var guests = await unitOfWork.Repository<Guest>().GetAll()
                .Where(guest => eventGuests.Any(eventGuest => eventGuest.GuestId == guest.Id))
                .ToListAsync();
            
            var eventGuestInvitationRsvps = await unitOfWork.Repository<EventGuestInvitationRsvp>().GetAll()
                .Where(eventGuestInvitationRsvp =>
                    eventGuestInvitations.Any(eventGuestInvitation => eventGuestInvitation.EventGuestInvitationRsvps.Contains(eventGuestInvitationRsvp.Id)))
                .ToListAsync();

            var model = MapEventGuest(eventInvitation, eventGuests, guests, eventGuestInvitations, eventGuestInvitationRsvps);
            
            return Ok(new OkResponse<IEnumerable<EventGuestModel>>(string.Empty) { Data = model});
        }

        private IEnumerable<EventGuestModel> MapEventGuest(EventInvitation eventInvitation, 
            IEnumerable<EventGuest> eventGuests,
            IEnumerable<Guest> guests,
            IEnumerable<EventGuestInvitation> eventGuestInvitations,
            IEnumerable<EventGuestInvitationRsvp> eventGuestInvitationRsvps)
        {
            foreach (var eventGuest in eventGuests)
            {
                var guest = guests.FirstOrDefault(guest => guest.Id == eventGuest.GuestId);
                var filteredEventGuestInvitations = eventGuestInvitations.Where(eventGuestInvitation =>
                    eventGuest.EventGuestInvitations.Contains(eventGuestInvitation.Id));

                yield return new EventGuestModel()
                {
                    EventId = eventInvitation.EventId,
                    GuestId = eventGuest.GuestId,
                    MaxGuests = eventGuest.MaxGuests,
                    LastName = guest.LastName,
                    FirstName = guest.FirstName,
                    NickName = guest.NickName,
                    EventGuestId = eventGuest.Id,
                    EventGuestInvitations = MapEventGuestInvitations(filteredEventGuestInvitations, eventGuestInvitationRsvps),
                };
            }
        }

        private IEnumerable<EventGuestInvitationModel> MapEventGuestInvitations(IEnumerable<EventGuestInvitation> eventGuestInvitations,
            IEnumerable<EventGuestInvitationRsvp> eventGuestInvitationRsvps)
        {
            return eventGuestInvitations.Select(eventGuestInvitation => new EventGuestInvitationModel()
            {
                MaxGuests = eventGuestInvitation.MaxGuests,
                Code = eventGuestInvitation.Code,
                EventGuestInvitationId = eventGuestInvitation.Id,
                Rsvps = eventGuestInvitationRsvps.Where(eventGuestInvitationRsvp => eventGuestInvitation.EventGuestInvitationRsvps.Contains(eventGuestInvitationRsvp.Id))
                    .OrderByDescending(eventGuestInvitationRsvp => eventGuestInvitationRsvp.DateCreated)
                    .Select(eventGuestInvitationRsvp => new EventGuestInvitationRsvpModel()
                    {
                        Response = eventGuestInvitationRsvp.Response,
                        GuestNames = eventGuestInvitationRsvp.GuestNames,
                        DateCreated = eventGuestInvitationRsvp.DateCreated,
                        EventGuestInvitationRsvpId = eventGuestInvitationRsvp.Id,
                    })
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventInvitationData data)
        {
            return await base.Post(new EventInvitation
            {
                EventId = data.EventId,
                Name = data.Name,
                Description = data.Description ?? string.Empty,
                Html = data.Html ?? string.Empty
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventInvitationData data)
        {
            var eventInvitation = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventInvitation);

            eventInvitation.EventId = data.EventId;
            eventInvitation.Name = data.Name;
            eventInvitation.Description = data.Description ?? string.Empty;
            eventInvitation.Html = data.Html ?? string.Empty;

            return await base.Put(eventInvitation);
        }
    }
}
