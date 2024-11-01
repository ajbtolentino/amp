using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestRoleController(IUnitOfWork unitOfWork, ILogger<GuestRoleController> logger) : ApiBaseController<Role, Guid>(unitOfWork, logger)
    {
        public record GuestRoleData(Guid EventId, string? Name, string? Description);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GuestRoleData request)
        {
            ArgumentException.ThrowIfNullOrEmpty(request.Name);

            return await base.Post(new Role()
            {
                EventId = request.EventId,
                Name = request.Name,
                Description = request.Description ?? string.Empty
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GuestRoleData request)
        {
            ArgumentException.ThrowIfNullOrEmpty(request.Name);

            var guestRole = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(guestRole);

            guestRole.EventId = request.EventId;
            guestRole.Name = request.Name;
            guestRole.Description = request.Description ?? string.Empty;

            return await base.Put(guestRole);
        }
    }
}
