using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventGuestRoleController(IUnitOfWork unitOfWork, ILogger<EventGuestRoleController> logger)
    : ApiBaseController<EventGuestRole, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route(nameof(GetByEventGuestIds))]
    public virtual IActionResult GetByEventGuestIds([FromQuery] List<Guid> eventGuestIds)
    {
        var eventGuestRoles = EntityRepository.GetAll().Where(entity => eventGuestIds.Contains(entity.EventGuestId));

        return Ok(new OkResponse<IEnumerable<EventGuestRole>>(string.Empty) { Data = eventGuestRoles });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventGuestRoleRequest request)
    {
        return await base.Post(new EventGuestRole
        {
            EventGuestId = request.EventGuestId,
            RoleId = request.RoleId
        });
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestRoleRequest request)
    {
        var eventGuestRole = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventGuestRole);

        eventGuestRole.EventGuestId = request.EventGuestId;
        eventGuestRole.RoleId = request.RoleId;

        return await base.Put(eventGuestRole);
    }

    public record EventGuestRoleRequest(Guid EventGuestId, Guid RoleId);
}