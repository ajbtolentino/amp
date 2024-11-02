using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IUnitOfWork unitOfWork, ILogger<EventController> logger)
    : ApiBaseController<Event, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{eventId:guid}/roles")]
    public IActionResult GetRoles(Guid eventId)
    {
        var eventRoles = unitOfWork.Repository<Role>().GetAll().Where(role => role.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<Role>>(string.Empty) { Data = eventRoles });
    }

    [HttpGet]
    [Route("{eventId:guid}/guests")]
    public IActionResult GetGuests(Guid eventId)
    {
        var eventGuests = unitOfWork.Repository<EventGuest>().GetAll()
            .Where(eventGuest => eventGuest.EventId == eventId)
            .Include(eventGuest => eventGuest.Guest)
            .Include(eventGuest => eventGuest.EventGuestRoles)
            .ThenInclude(eventGuestRole => eventGuestRole.Role)
            .Include(eventGuest => eventGuest.EventGuestInvitations)
            .ThenInclude(eventGuestInvitation => eventGuestInvitation.EventGuestInvitationRsvps)
            .ThenInclude(eventGuestInvitationRsvp => eventGuestInvitationRsvp.EventGuestInvitationRsvpItems)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventGuest>>(string.Empty) { Data = eventGuests });
    }

    [HttpGet]
    [Route("{eventId:guid}/invitations")]
    public IActionResult GetInvitations(Guid eventId)
    {
        var eventInvitations = unitOfWork.Repository<EventInvitation>().GetAll()
            .Include(_ => _.EventGuestInvitations).ThenInclude(_ => _.EventGuestInvitationRsvps)
            .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
            .Include(_ => _.EventGuestInvitations).ThenInclude(_ => _.EventGuest)
            .Where(eventInvitation => eventInvitation.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventInvitation>>(string.Empty) { Data = eventInvitations });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventRequest request)
    {
        try
        {
            unitOfWork.BeginTransaction();

            var eventType = unitOfWork.Repository<EventType>().GetAll().Include(_ => _.EventTypeRoles)
                .FirstOrDefault(_ => _.Id == request.EventTypeId);

            ArgumentNullException.ThrowIfNull(eventType);

            var newEvent = await entityRepository.Add(new Event
            {
                Title = request.Title,
                EventTypeId = request.EventTypeId,
                Description = request.Description ?? string.Empty,
                Location = request.Location ?? string.Empty,
                MaxGuests = request.MaxGuests,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            });

            foreach (var role in eventType.EventTypeRoles.ToList())
                await unitOfWork.Repository<Role>().Add(new Role
                {
                    EventId = newEvent.Id,
                    Name = role.Name,
                    Description = role.Description
                });

            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Event>(string.Empty) { Data = newEvent });
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTransactionAsync();
            logger.LogError(e.Message, e);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventRequest request)
    {
        var @event = await entityRepository.Get(id);

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

    public record EventRequest(
        string Title,
        Guid EventTypeId,
        string? Description,
        string? Location,
        int MaxGuests,
        DateTime StartDate,
        DateTime EndDate);
}