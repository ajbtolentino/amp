using System.Security.Claims;
using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class EventController(IUnitOfWork unitOfWork) : ApiBaseController<Event, Guid>(unitOfWork)
    {
        public record EventData(string Name, string Description);

        [HttpGet]
        public new IActionResult GetAll()
        {
            return base.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventData data)
        {
            return await base.Post(new Event
            {
                Name = data.Name,
                Description = data.Description,
                DateCreated = DateTime.Now,
                CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.Name = data.Name;
            entity.Description = data.Description;
            entity.DateUpdated = DateTime.Now;
            entity.UpdatedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            return await base.Put(entity);
        }
    }
}
