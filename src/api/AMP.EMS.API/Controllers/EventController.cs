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
            var eventRoles = unitOfWork.Repository<EventRole>().GetAll().Where(role => role.EventId == eventId).AsNoTracking();

            return Ok(new OkResponse<IEnumerable<EventRole>>(string.Empty) { Data = eventRoles });
        }

        [HttpGet]
        [Route("{eventId:guid}/guests")]
        public IActionResult GetGuests(Guid eventId)
        {
            var eventGuests = unitOfWork.Repository<EventGuest>().GetAll()
                                        .Where(eventGuest => eventGuest.EventId == eventId)
                                        .Include(eventGuest => eventGuest.Guest)
                                        .Include(eventGuest => eventGuest.EventGuestRoles)
                                        .Include(eventGuest => eventGuest.EventGuestInvitations)
                                            .ThenInclude(eventGuestInvitation => eventGuestInvitation.EventGuestInvitationRsvps)
                                            .ThenInclude(eventGuestInvitationRsvp => eventGuestInvitationRsvp.EventGuestInvitationRsvpItems)
                                        .AsNoTracking();

            return Ok(new OkResponse<IEnumerable<EventGuest>>(string.Empty) { Data = eventGuests });
        }
        
        [HttpGet]
        [Route("{eventId:guid}/invitations")]
        public async Task<IActionResult> GetInvitations(Guid eventId)
        {
            var eventInvitations = unitOfWork.Repository<EventInvitation>().GetAll()
                .Where(eventInvitation => eventInvitation.EventId == eventId)
                .AsNoTracking();
            
            return Ok(new OkResponse<IEnumerable<EventInvitation>>(string.Empty) { Data = eventInvitations });
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
    }
}
