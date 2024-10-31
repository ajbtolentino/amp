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
    public class RsvpController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuestInvitationRsvp, Guid>(unitOfWork)
    {
        public record RsvpRequest(Guid EventGuestInvitationId, [JsonConverter(typeof(StringEnumConverter))] Core.Constants.RsvpResponse Response, string? PhoneNumber, IEnumerable<string>? GuestNames);
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] RsvpRequest request)
        {
            var guestInvitation = await unitOfWork.Repository<EventGuestInvitation>().Get(request.EventGuestInvitationId);

            ArgumentNullException.ThrowIfNull(guestInvitation);

            try
            {
                unitOfWork.BeginTransaction();
                
                var rsvpEntity = await this.unitOfWork.Repository<EventGuestInvitationRsvp>().Add(new EventGuestInvitationRsvp()
                {
                    Response = request.Response
                });

                guestInvitation.EventGuestInvitationRsvps.Add(rsvpEntity);

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();

                return Ok(new OkResponse<EventGuestInvitationRsvp>(string.Empty) { Data = rsvpEntity });
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }
    }
}
