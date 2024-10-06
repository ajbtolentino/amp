using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController(IUnitOfWork unitOfWork) : ApiBaseController<RSVP, Guid>(unitOfWork)
    {
        public record RSVPData(string Code, RSVPResponse Response, string PhoneNumber);

        [HttpPost]
        public IActionResult Post([FromBody] RSVPData data)
        {
            var invitation = unitOfWork.Repository<Invitation>().GetAll().FirstOrDefault(_ => _.Code == data.Code);

            if (invitation == null) return BadRequest();

            if (!Enum.GetValues<RSVPResponse>().Contains(data.Response)) return BadRequest();

            return base.Post(new RSVP
            {
                InvitationId = invitation.Id,
                Response = data.Response
            });
        }
    }
}
