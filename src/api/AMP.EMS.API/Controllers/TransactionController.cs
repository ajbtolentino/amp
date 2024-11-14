using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class TransactionController(IUnitOfWork unitOfWork, ILogger<TransactionController> logger)
    : ApiBaseController<Transaction, Guid>(unitOfWork, logger)
{
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] TransactionRequest request)
    {
        var transaction = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(transaction);

        transaction.Amount = request.Amount;
        transaction.ReferenceNumber = request.ReferenceNumber;
        transaction.Description = request.Description;
        transaction.TransactionDate = request.TransactionDate;
        transaction.TransactionTypeId = request.TransactionTypeId;

        return await base.Put(transaction);
    }

    public record TransactionRequest(
        Guid TransactionTypeId,
        decimal Amount,
        DateTime TransactionDate,
        string? Description,
        string? ReferenceNumber);
}