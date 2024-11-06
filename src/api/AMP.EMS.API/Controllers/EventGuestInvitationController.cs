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
    [Route("{code}/[action]")]
    [AllowAnonymous]
    public IActionResult Rsvp(string code)
    {
        var eventGuestInvitation = UnitOfWork.Set<EventGuestInvitation>().GetAll()
            .Where(_ => _.Code == code)
            .Include(_ => _.EventInvitation)
            .Include(_ => _.EventGuestInvitationRsvps)
            .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
            .Include(eventGuestInvitation => eventGuestInvitation.EventGuest)
            .ThenInclude(eventGuest => eventGuest.Guest)
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