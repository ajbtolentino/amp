using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuestInvitationRSVP, Guid>(unitOfWork)
    {
        public record RSVPItemData(string? Name);
        public record RSVPData(Guid EventGuestInvitationId, [JsonConverter(typeof(StringEnumConverter))] RSVPResponse Response, string? PhoneNumber, IEnumerable<RSVPItemData>? EventGuestInvitationRSVPItems);

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] RSVPData request)
        {
            var eventGuestInvitation = await unitOfWork.Repository<EventGuestInvitation>().Get(request.EventGuestInvitationId);

            if (eventGuestInvitation == null) return BadRequest();

            if (!Enum.GetValues<RSVPResponse>().Contains(request.Response)) return BadRequest();

            try
            {
                this.unitOfWork.BeginTransaction();

                var rsvpEntity = await this.unitOfWork.Repository<EventGuestInvitationRSVP>().Add(new EventGuestInvitationRSVP
                {
                    EventGuestInvitationId = eventGuestInvitation.Id,
                    Response = request.Response,
                    PhoneNumber = request.PhoneNumber ?? string.Empty
                });

                foreach (var item in request.EventGuestInvitationRSVPItems)
                {
                    if (string.IsNullOrEmpty(item.Name)) continue;

                    await this.unitOfWork.Repository<EventGuestInvitationRSVPItem>().Add(new EventGuestInvitationRSVPItem
                    {
                        EventGuestInvitationRSVPId = rsvpEntity.Id,
                        GuestName = item.Name
                    });
                }

                await this.unitOfWork.SaveChangesAsync();
                await this.unitOfWork.CommitTransactionAsync();

                return Ok(new OkResponse<EventGuestInvitationRSVP>(string.Empty) { Data = rsvpEntity });
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }
    }
}
