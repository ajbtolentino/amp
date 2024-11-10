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
    : ApiBaseController<EventGuestInvitationRsvp, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route(nameof(GetByEventGuestInvitationIds))]
    public virtual IActionResult GetByEventGuestInvitationIds([FromQuery] List<Guid> eventGuestInvitationIds)
    {
        var eventGuestInvitationRsvps =
            EntityRepository.GetAll().Where(entity => eventGuestInvitationIds.Contains(entity.EventGuestInvitationId));

        return Ok(new OkResponse<IEnumerable<EventGuestInvitationRsvp>>(string.Empty)
            { Data = eventGuestInvitationRsvps });
    }

    [HttpGet(nameof(GetItemsByIds))]
    public virtual IActionResult GetItemsByIds([FromQuery] List<Guid> ids)
    {
        var eventGuestInvitationRsvpItems = UnitOfWork.Set<EventGuestInvitationRsvpItem>().GetAll().AsNoTracking()
            .Where(_ => ids.Contains(_.EventGuestInvitationRsvpId));

        return Ok(new OkResponse<IEnumerable<EventGuestInvitationRsvpItem>>(string.Empty)
            { Data = eventGuestInvitationRsvpItems });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] RsvpRequest request)
    {
        var guestInvitation = await UnitOfWork.Set<EventGuestInvitation>().Get(request.EventGuestInvitationId);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        try
        {
            UnitOfWork.BeginTransaction();

            var rsvpEntity = new EventGuestInvitationRsvp
            {
                Response = request.Response
            };

            foreach (var item in request.GuestNames?.Where(_ => !string.IsNullOrEmpty(_)))
                rsvpEntity.EventGuestInvitationRsvpItems.Add(new EventGuestInvitationRsvpItem
                {
                    Name = item
                });

            await UnitOfWork.Set<EventGuestInvitationRsvp>().Add(rsvpEntity);

            guestInvitation.EventGuestInvitationRsvps.Add(rsvpEntity);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventGuestInvitationRsvp>(string.Empty) { Data = rsvpEntity });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public record RsvpRequest(
        Guid EventGuestInvitationId,
        [JsonConverter(typeof(StringEnumConverter))]
        RsvpResponse Response,
        string? PhoneNumber,
        IEnumerable<string>? GuestNames);
}