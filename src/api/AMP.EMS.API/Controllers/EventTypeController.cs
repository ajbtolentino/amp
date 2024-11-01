using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger) : ApiBaseController<EventType, Guid>(unitOfWork, logger)
    {
        public record EventTypeData(string Name, string? Description);

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
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventTypeData data)
        {
            var eventType = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventType);

            eventType.Name = data.Name;
            eventType.Description = data.Description ?? string.Empty;

            return await base.Put(eventType);
        }
    }
}
