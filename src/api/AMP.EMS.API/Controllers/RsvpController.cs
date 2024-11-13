using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMP.EMS.API.Controllers;

public class RsvpController(IUnitOfWork unitOfWork, ILogger<RsvpController> logger)
    : ApiBaseController<GuestInvitationRsvp, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("[action]")]
    public virtual IActionResult GetByGuestInvitationIds([FromQuery] List<Guid> guestInvitationIds)
    {
        var guestInvitationRsvps =
            EntityRepository.GetAll().Where(entity => guestInvitationIds.Contains(entity.GuestInvitationId));

        return Ok(new OkResponse<IEnumerable<GuestInvitationRsvp>>(string.Empty)
            { Data = guestInvitationRsvps });
    }

    [HttpGet(nameof(GetItemsByIds))]
    public virtual IActionResult GetItemsByIds([FromQuery] List<Guid> ids)
    {
        var guestInvitationRsvpItems = UnitOfWork.Set<GuestInvitationRsvpItem>().GetAll().AsNoTracking()
            .Where(_ => ids.Contains(_.GuestInvitationRsvpId));

        return Ok(new OkResponse<IEnumerable<GuestInvitationRsvpItem>>(string.Empty)
            { Data = guestInvitationRsvpItems });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] RsvpRequest request)
    {
        var guestInvitation = await UnitOfWork.Set<GuestInvitation>().Get(request.GuestInvitationId);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        try
        {
            UnitOfWork.BeginTransaction();

            var rsvpEntity = new GuestInvitationRsvp
            {
                Response = request.Response
            };

            foreach (var item in request.GuestNames?.Where(_ => !string.IsNullOrEmpty(_)))
                rsvpEntity.GuestInvitationRsvpItems.Add(new GuestInvitationRsvpItem
                {
                    Name = item
                });

            await UnitOfWork.Set<GuestInvitationRsvp>().Add(rsvpEntity);

            guestInvitation.GuestInvitationRsvps.Add(rsvpEntity);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<GuestInvitationRsvp>(string.Empty) { Data = rsvpEntity });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public record RsvpRequest(
        Guid GuestInvitationId,
        [JsonConverter(typeof(StringEnumConverter))]
        RsvpResponse Response,
        string? PhoneNumber,
        IEnumerable<string>? GuestNames);
}