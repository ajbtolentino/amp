using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController(IUnitOfWork unitOfWork) : ApiBaseController<EventType, Guid>(unitOfWork)
    {
        public record EventTypeData(string Name, string? Description);

        [HttpGet]
        public new IActionResult GetAll()
        {
            return base.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventTypeData data)
        {
            return await base.Post(new EventType
            {
                Name = data.Name,
                Description = data.Description ?? string.Empty
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventTypeData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.Name = data.Name;
            entity.Description = data.Description ?? string.Empty;

            return await base.Put(entity);
        }
    }
}
