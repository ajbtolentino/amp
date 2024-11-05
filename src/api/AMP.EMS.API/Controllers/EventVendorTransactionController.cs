using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
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
            unitOfWork.BeginTransaction();

            var transaction = await unitOfWork.Repository<Transaction>().Add(new Transaction
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

            return await base.Post(new EventVendorTransaction
            {
                EventId = request.EventId,
                VendorId = request.VendorId,
                TransactionId = transaction.Id
            });
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
                entityRepository.GetAll().Include(_ => _.Transaction).FirstOrDefault(_ => _.Id == id);

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