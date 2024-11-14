using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class GuestInvitationController(IUnitOfWork unitOfWork, ILogger<GuestInvitationController> logger)
    : ApiBaseController<GuestInvitation, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("[action]")]
    public virtual IActionResult GetByGuestIds([FromQuery] List<Guid> guestIds)
    {
        var guestInvitations =
            EntityRepository.GetAll().Where(entity => guestIds.Contains(entity.GuestId));

        return Ok(new OkResponse<IEnumerable<GuestInvitation>>(string.Empty) { Data = guestInvitations });
    }

    [HttpGet]
    [Route("[action]")]
    public virtual IActionResult GetByInvitationIds([FromQuery] List<Guid> invitationIds)
    {
        var guestInvitations =
            EntityRepository.GetAll().Where(entity => invitationIds.Contains(entity.InvitationId));

        return Ok(new OkResponse<IEnumerable<GuestInvitation>>(string.Empty) { Data = guestInvitations });
    }

    [HttpGet]
    [Route("{code}/[action]")]
    [AllowAnonymous]
    public IActionResult Rsvp(string code)
    {
        var guestInvitation = UnitOfWork.Set<GuestInvitation>()
            .GetAll()
            .AsNoTracking()
            .FirstOrDefault(_ => _.Code == code);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        guestInvitation.GuestInvitationRsvps = guestInvitation.GuestInvitationRsvps
            .OrderByDescending(_ => _.DateCreated).Take(1).AsEnumerable().ToList();

        ArgumentNullException.ThrowIfNull(guestInvitation);

        return Ok(new OkResponse<GuestInvitation>(string.Empty) { Data = guestInvitation });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GuestInvitationRequest request)
    {
        var guest = await UnitOfWork.Set<Guest>().Get(request.GuestId);

        ArgumentNullException.ThrowIfNull(guest);

        return await base.Post(new GuestInvitation
        {
            GuestId = request.GuestId,
            InvitationId = request.InvitationId,
            Code = InvitationHelper.GenerateCode(),
            Seats = guest.Seats
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GuestInvitationRequest request)
    {
        var guestInvitation = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        if (!string.IsNullOrEmpty(request.Code))
            guestInvitation.Code = request.Code;

        guestInvitation.InvitationId = request.InvitationId;
        guestInvitation.Seats = request.Seats;

        return await base.Put(guestInvitation);
    }

    public record GuestInvitationRequest(Guid InvitationId, Guid GuestId, string? Code, int Seats);

    private record RsvpResponse(
        Guest Guest,
        GuestInvitation GuestInvitation,
        Invitation Invitation);
}