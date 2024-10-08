using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class InvitationController(IUnitOfWork unitOfWork) : ApiBaseController<Invitation, Guid>(unitOfWork)
    {
        public record InvitationData(string Code, Guid EventId, Guid GuestId);

        [HttpGet]
        [Route("{eventId}/details")]
        public IActionResult GetAll(Guid? eventId)
        {
            if (!eventId.HasValue)
                return base.GetAll();

            var collection = base.entityRepository.GetAll().AsNoTracking()
                                .Where(_ => _.EventId == eventId)
                                .Include(_ => _.Guest);

            return Ok(new OkResponse<IEnumerable<Invitation>>(string.Empty) { Data = collection });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvitationData data)
        {
            return await base.Post(new Invitation
            {
                Code = data.Code,
                EventId = data.EventId,
                GuestId = data.GuestId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] InvitationData data)
        {
            return await base.Put(new Invitation
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
