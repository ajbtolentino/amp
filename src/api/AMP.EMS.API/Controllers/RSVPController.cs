using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController(IUnitOfWork unitOfWork) : ApiBaseController<RSVP, Guid>(unitOfWork)
    {
        public record RSVPData(Guid EventInvitationId, [JsonConverter(typeof(StringEnumConverter))] RSVPResponse Response, string? PhoneNumber);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RSVPData data)
        {
            var invitation = await unitOfWork.Repository<EventGuestInvitation>().Get(data.EventInvitationId);

            if (invitation == null) return BadRequest();

            if (!Enum.GetValues<RSVPResponse>().Contains(data.Response)) return BadRequest();

            return await base.Post(new RSVP
            {
                EventGuestInvitationId = invitation.Id,
                Response = data.Response,
                PhoneNumber = data.PhoneNumber ?? string.Empty
            });
        }
    }
}
