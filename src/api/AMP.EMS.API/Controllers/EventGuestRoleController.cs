using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventGuestRoleController(IUnitOfWork unitOfWork, ILogger<EventGuestRoleController> logger)
    : ApiBaseController<Role, Guid>(unitOfWork, logger)
{
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
        var eventGuestRole = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventGuestRole);

        eventGuestRole.EventId = request.EventId;
        eventGuestRole.Name = request.Name;
        eventGuestRole.Description = request.Description;

        return await base.Put(eventGuestRole);
    }

    public record EventGuestRoleRequest(Guid EventId, string Name, string Description);
}