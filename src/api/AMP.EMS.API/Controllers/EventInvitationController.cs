using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventInvitationController(IUnitOfWork unitOfWork, ILogger<EventInvitationController> logger)
    : ApiBaseController<EventInvitation, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{id:guid}/guests")]
    public IActionResult GetGuests(Guid id)
    {
        var eventGuestInvitations = UnitOfWork.Set<EventGuestInvitation>().GetAll()
            .Where(_ => _.EventInvitationId == id)
            .Include(_ => _.EventGuest).ThenInclude(_ => _.Guest)
            .Include(_ => _.EventGuestInvitationRsvps).ThenInclude(_ => _.EventGuestInvitationRsvpItems);

        ArgumentNullException.ThrowIfNull(eventGuestInvitations);

        return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventInvitationRequest request)
    {
        return await base.Post(new EventInvitation
        {
            EventId = request.EventId,
            Name = request.Name,
            Description = request.Description ?? string.Empty,
            Html = request.Html ?? string.Empty,
            RsvpDeadline = request.RsvpDeadline
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventInvitationRequest request)
    {
        var eventInvitation = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventInvitation);

        eventInvitation.EventId = request.EventId;
        eventInvitation.Name = request.Name;
        eventInvitation.Description = request.Description ?? string.Empty;
        eventInvitation.Html = request.Html ?? string.Empty;
        eventInvitation.RsvpDeadline = request.RsvpDeadline;

        return await base.Put(eventInvitation);
    }

    public record EventInvitationRequest(
        Guid EventId,
        string Name,
        string? Description,
        string? Html,
        DateTime? RsvpDeadline);
}