using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuest, Guid>(unitOfWork)
    {
        public record EventGuestData(Guid EventId, Guid GuestId);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestData data)
        {
            return await base.Post(new EventGuest
            {
                EventId = data.EventId,
                GuestId = data.GuestId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.EventId = data.EventId;
            entity.GuestId = data.GuestId;

            return await base.Put(entity);
        }
    }
}
