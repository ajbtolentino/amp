using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventVendorTypeBudgetController(IUnitOfWork unitOfWork, ILogger<EventVendorTypeBudgetController> logger)
    : ApiBaseController<EventVendorTypeBudget, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventVendorTypeBudgetRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var eventVendorTypeBudget = await EntityRepository.Add(new EventVendorTypeBudget
            {
                Amount = request.Amount,
                Description = request.Description,
                EventId = request.EventId,
                VendorTypeId = request.VendorTypeId
            });

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventVendorTypeBudget>(string.Empty) { Data = eventVendorTypeBudget });
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorTypeBudgetRequest request)
    {
        var entity = await EntityRepository.Get(id);

        if (entity == null) return BadRequest();

        entity.Amount = request.Amount;
        entity.Description = request.Description;
        entity.VendorTypeId = request.VendorTypeId;

        return await base.Put(entity);
    }

    public record EventVendorTypeBudgetRequest(Guid EventId, Guid VendorTypeId, string? Description, decimal Amount);
}