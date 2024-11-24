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
            .AsSplitQuery()
            .Where(_ => _.Code == code)
            .Include(_ => _.Invitation).ThenInclude(_ => _.Content)
            .Include(_ => _.Guest)
            .FirstOrDefault();

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
            Seats = request.Seats,
            Data = request.Data ?? string.Empty
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
        guestInvitation.Data = request.Data ?? string.Empty;

        return await base.Put(guestInvitation);
    }

    public override async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            EntityRepository.Delete(id);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public record GuestInvitationRequest(Guid InvitationId, Guid GuestId, string? Code, int Seats, string? Data);
}