using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController(IUnitOfWork unitOfWork) : ApiBaseController<Invitation, Guid>(unitOfWork)
    {
        public record InvitationData(string Code, Guid EventId, Guid GuestId);

        [HttpPost]
        public IActionResult Post([FromBody] InvitationData data)
        {
            return base.Post(new Invitation
            {
                Code = data.Code,
                EventId = data.EventId,
                GuestId = data.GuestId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] InvitationData data)
        {
            return base.Put(new Invitation
            {
                Id = id,
                Code = data.Code,
                EventId = data.EventId,
                GuestId = data.GuestId,
                DateUpdated = DateTime.Now
            });
        }
    }
}
