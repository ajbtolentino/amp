using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventGuestInvitationController(IUnitOfWork unitOfWork, ILogger<EventGuestInvitationController> logger)
    : ApiBaseController<EventGuestInvitation, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route(nameof(GetByEventGuestIds))]
    public virtual IActionResult GetByEventGuestIds([FromQuery] List<Guid> eventGuestIds)
    {
        var eventGuestInvitations =
            EntityRepository.GetAll().Where(entity => eventGuestIds.Contains(entity.EventGuestId));

        return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
    }

    [HttpGet]
    [Route(nameof(GetByEventInvitationIds))]
    public virtual IActionResult GetByEventInvitationIds([FromQuery] List<Guid> eventInvitationIds)
    {
        var eventGuestInvitations =
            EntityRepository.GetAll().Where(entity => eventInvitationIds.Contains(entity.EventInvitationId));

        return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
    }

    [HttpGet]
    [Route("{code}/[action]")]
    [AllowAnonymous]
    public IActionResult Rsvp(string code)
    {
        var eventGuestInvitation = UnitOfWork.Set<EventGuestInvitation>().GetAll()
            .AsNoTracking()
            .Where(_ => _.Code == code)
            .FirstOrDefault();

        ArgumentNullException.ThrowIfNull(eventGuestInvitation);

        eventGuestInvitation.EventGuestInvitationRsvps = eventGuestInvitation.EventGuestInvitationRsvps
            .OrderByDescending(_ => _.DateCreated).Take(1).AsEnumerable().ToList();

        ArgumentNullException.ThrowIfNull(eventGuestInvitation);

        return Ok(new OkResponse<EventGuestInvitation>(string.Empty) { Data = eventGuestInvitation });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventGuestInvitationRequest request)
    {
        var eventGuest = await UnitOfWork.Set<EventGuest>().Get(request.EventGuestId);

        ArgumentNullException.ThrowIfNull(eventGuest);

        return await base.Post(new EventGuestInvitation
        {
            EventGuestId = request.EventGuestId,
            EventInvitationId = request.EventInvitationId,
            Code = InvitationHelper.GenerateCode(),
            Seats = eventGuest.Seats
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestInvitationRequest request)
    {
        var guestInvitation = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        if (!string.IsNullOrEmpty(request.Code))
            guestInvitation.Code = request.Code;

        guestInvitation.EventInvitationId = request.EventInvitationId;
        guestInvitation.Seats = request.Seats;

        return await base.Put(guestInvitation);
    }

    public record EventGuestInvitationRequest(Guid EventInvitationId, Guid EventGuestId, string? Code, int Seats);

    private record RsvpResponse(
        Guest Guest,
        EventGuestInvitation EventGuestInvitation,
        EventInvitation EventInvitation);
}