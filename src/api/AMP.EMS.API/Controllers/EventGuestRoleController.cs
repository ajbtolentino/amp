using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestRoleController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuestRole, Guid>(unitOfWork)
    {
        public record EventGuestRoleData(Guid EventGuestId, Guid EventRoleId);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestRoleData data)
        {
            return await base.Post(new EventGuestRole
            {
                EventGuestId = data.EventGuestId,
                EventRoleId = data.EventRoleId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestRoleData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.EventGuestId = data.EventGuestId;
            entity.EventRoleId = data.EventRoleId;

            return await base.Put(entity);
        }
    }
}
