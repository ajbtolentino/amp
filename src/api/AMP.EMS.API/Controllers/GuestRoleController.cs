using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class GuestRoleController(IUnitOfWork unitOfWork, ILogger<GuestRoleController> logger)
    : ApiBaseController<GuestRole, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("[action]")]
    public virtual IActionResult GetByGuestIds([FromQuery] List<Guid> guestIds)
    {
        var guestRoles = EntityRepository.GetAll().Where(entity => guestIds.Contains(entity.GuestId));

        return Ok(new OkResponse<IEnumerable<GuestRole>>(string.Empty) { Data = guestRoles });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GuestRoleRequest request)
    {
        return await base.Post(new GuestRole
        {
            GuestId = request.GuestId,
            RoleId = request.RoleId
        });
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GuestRoleRequest request)
    {
        var guestRole = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(guestRole);

        guestRole.GuestId = request.GuestId;
        guestRole.RoleId = request.RoleId;

        return await base.Put(guestRole);
    }

    public record GuestRoleRequest(Guid GuestId, Guid RoleId);
}