using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class EventVendorTransactionController(IUnitOfWork unitOfWork, ILogger<EventVendorTransactionController> logger)
    : ApiBaseController<EventVendorTransaction, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventVendorTransactionRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var transaction = await UnitOfWork.Set<Transaction>().Add(new Transaction
            {
                Id = Guid.NewGuid(),
                ReferenceNumber = request.ReferenceNumber,
                Description = request.Description,
                Amount = request.Amount,
                CreditAccountId = request.CreditAccountId,
                DebitAccountId = request.DebitAccountId,
                TransactionTypeId = request.TransactionTypeId,
                TransactionDate = request.TransactionDate
            });

            var eventVendorTransaction = await EntityRepository.Add(new EventVendorTransaction
            {
                EventId = request.EventId,
                VendorId = request.VendorId,
                TransactionId = transaction.Id
            });

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventVendorTransaction>(string.Empty) { Data = eventVendorTransaction });
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorTransactionRequest request)
    {
        try
        {
            var eventVendorTransaction =
                EntityRepository.GetAll().Include(_ => _.Transaction).FirstOrDefault(_ => _.Id == id);

            ArgumentNullException.ThrowIfNull(eventVendorTransaction);

            eventVendorTransaction.VendorId = request.VendorId;
            eventVendorTransaction.EventId = request.EventId;
            eventVendorTransaction.Transaction.CreditAccountId = request.CreditAccountId;
            eventVendorTransaction.Transaction.DebitAccountId = request.DebitAccountId;
            eventVendorTransaction.Transaction.Description = request.Description;
            eventVendorTransaction.Transaction.ReferenceNumber = request.ReferenceNumber;
            eventVendorTransaction.Transaction.Amount = request.Amount;
            eventVendorTransaction.Transaction.TransactionDate = request.TransactionDate;

            return await base.Put(eventVendorTransaction);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return Problem(e.Message);
        }
    }

    public record EventVendorTransactionRequest(
        Guid EventId,
        Guid VendorId,
        Guid DebitAccountId,
        Guid CreditAccountId,
        Guid TransactionTypeId,
        DateTime TransactionDate,
        string Description,
        string ReferenceNumber,
        decimal Amount);
}