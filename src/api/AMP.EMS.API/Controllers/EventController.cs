using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IUnitOfWork unitOfWork) : ApiBaseController<Event, Guid>(unitOfWork)
    {
        public record EventData(string Title, Guid EventTypeId, string? Description, string? Location, int MaxGuests, DateTime StartDate, DateTime EndDate);

        [HttpGet]
        public override IActionResult GetAll()
        {
            var entities = this.entityRepository.GetAll().Include(_ => _.EventType).AsNoTracking();

            return Ok(new OkResponse<IEnumerable<Event>>(string.Empty) { Data = entities });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventData data)
        {
            return await base.Post(new Event
            {
                Title = data.Title,
                EventTypeId = data.EventTypeId,
                Description = data.Description ?? string.Empty,
                Location = data.Location ?? string.Empty,
                MaxGuests = data.MaxGuests,
                StartDate = data.StartDate,
                EndDate = data.EndDate
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.Title = data.Title;
            entity.EventTypeId = data.EventTypeId;
            entity.Description = data.Description ?? string.Empty;
            entity.Location = data.Location ?? string.Empty;
            entity.MaxGuests = data.MaxGuests;
            entity.StartDate = data.StartDate;
            entity.EndDate = data.EndDate;

            return await base.Put(entity);
        }
    }
}
