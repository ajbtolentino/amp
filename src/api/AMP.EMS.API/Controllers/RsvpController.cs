using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
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

        try
        {
            UnitOfWork.BeginTransaction();

            guestInvitation.Data = request.Data;

            UnitOfWork.Set<GuestInvitation>().Update(guestInvitation);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<GuestInvitation>(string.Empty) { Data = guestInvitation });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public record RsvpRequest(string Data);
}