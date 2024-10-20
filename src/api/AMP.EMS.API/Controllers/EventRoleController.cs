using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRoleController(IUnitOfWork unitOfWork) : ApiBaseController<EventRole, Guid>(unitOfWork)
    {
        public record EventRoleData(Guid EventId, string? Name, string? Description);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventRoleData data)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(data.Name);

            return await base.Post(new EventRole
            {
                EventId = data.EventId,
                Name = data.Name,
                Description = data.Description ?? string.Empty
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventRoleData data)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(data.Name);

            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.EventId = data.EventId;
            entity.Name = data.Name;
            entity.Description = data.Description ?? string.Empty;

            return await base.Put(entity);
        }
    }
}
