using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class RsvpController(IUnitOfWork unitOfWork, ILogger<RsvpController> logger)
    : ApiBaseController<GuestInvitation, Guid>(unitOfWork, logger)
{
    [HttpPut("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Put(Guid id, [FromBody] RsvpRequest request)
    {
        var guestInvitation = await UnitOfWork.Set<GuestInvitation>().Get(id);

        ArgumentNullException.ThrowIfNull(guestInvitation);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Data);

        guestInvitation.Data = request.Data;

        return await base.Put(guestInvitation);
    }

    public record RsvpRequest(string Data);
}