using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RsvpController(IUnitOfWork unitOfWork, ILogger<RsvpController> logger)
    : ApiBaseController<EventGuestInvitationRsvp, Guid>(unitOfWork, logger)
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] RsvpRequest request)
    {
        var guestInvitation = await unitOfWork.Repository<EventGuestInvitation>().Get(request.EventGuestInvitationId);

        ArgumentNullException.ThrowIfNull(guestInvitation);

        try
        {
            unitOfWork.BeginTransaction();

            var rsvpEntity = new EventGuestInvitationRsvp
            {
                Response = request.Response
            };

            foreach (var item in request.GuestNames?.Where(_ => !string.IsNullOrEmpty(_)))
                rsvpEntity.EventGuestInvitationRsvpItems.Add(new EventGuestInvitationRsvpItem
                {
                    Name = item
                });

            await unitOfWork.Repository<EventGuestInvitationRsvp>().Add(rsvpEntity);

            guestInvitation.EventGuestInvitationRsvps.Add(rsvpEntity);

            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventGuestInvitationRsvp>(string.Empty) { Data = rsvpEntity });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await unitOfWork.RollbackTransactionAsync();
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