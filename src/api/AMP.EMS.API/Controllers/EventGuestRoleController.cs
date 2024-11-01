using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestRoleController(IUnitOfWork unitOfWork) : ApiBaseController<Role, Guid>(unitOfWork)
    {
        public record EventGuestRoleRequest(Guid EventId, string Name, string Description);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestRoleRequest request)
        {
            return await base.Post(new Role
            {
                EventId = request.EventId,
                Name = request.Name,
                Description = request.Description
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestRoleRequest request)
        {
            var eventGuestRole = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventGuestRole);

            eventGuestRole.EventId = request.EventId;
            eventGuestRole.Name = request.Name;
            eventGuestRole.Description = request.Description;

            return await base.Put(eventGuestRole);
        }
    }
}
