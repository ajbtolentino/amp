using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractPaymentController(
    IUnitOfWork unitOfWork,
    ILogger<EventVendorContractPaymentStateController> logger)
    : ApiBaseController<EventVendorContractPayment, Guid>(unitOfWork, logger)
{
    [HttpPost("{id:guid}/transaction")]
    public async Task<IActionResult> ContractTransaction(Guid id, [FromBody] TransactionRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var eventVendorContractPayment = await EntityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventVendorContractPayment);

            var eventVendorContract = await UnitOfWork.Set<EventVendorContract>()
                .Get(eventVendorContractPayment.EventVendorContractId);

            ArgumentNullException.ThrowIfNull(eventVendorContract);

            var eventAccount = UnitOfWork.Set<EventAccount>().GetAll().AsNoTracking()
                .FirstOrDefault(_ => _.EventId == eventVendorContract.EventId);

            ArgumentNullException.ThrowIfNull(eventAccount);

            var vendorAccount = UnitOfWork.Set<VendorAccount>().GetAll().AsNoTracking()
                .FirstOrDefault(_ => _.VendorId == eventVendorContract.VendorId);

            ArgumentNullException.ThrowIfNull(vendorAccount);

            var transaction = await UnitOfWork.Set<Transaction>().Add(new Transaction
            {
                DebitAccountId = eventAccount.AccountId,
                CreditAccountId = vendorAccount.AccountId,
                Amount = eventVendorContractPayment.DueAmount,
                TransactionDate = request.TransactionDate,
                ReferenceNumber = request.ReferenceNumber,
                Description = request.Description,
                TransactionTypeId = request.TransactionTypeId
            });

            eventVendorContractPayment.TransactionId = transaction.Id;

            EntityRepository.Update(eventVendorContractPayment);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventVendorContractPayment>(string.Empty) { Data = eventVendorContractPayment });
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventVendorContractPaymentRequest request)
    {
        return await base.Post(new EventVendorContractPayment
        {
            EventVendorContractId = request.EventVendorContractId,
            EventVendorContractPaymentTypeId = request.EventVendorContractPaymentTypeId,
            EventVendorContractPaymentStateId = request.EventVendorContractPaymentStateId,
            DueDate = request.DueDate,
            DueAmount = request.DueAmount
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorContractPaymentRequest request)
    {
        var eventVendorContractPayment = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContractPayment);

        eventVendorContractPayment.EventVendorContractPaymentTypeId = request.EventVendorContractPaymentTypeId;
        eventVendorContractPayment.EventVendorContractPaymentStateId = request.EventVendorContractPaymentStateId;
        eventVendorContractPayment.DueAmount = request.DueAmount;
        eventVendorContractPayment.DueDate = request.DueDate;

        return await base.Put(eventVendorContractPayment);
    }

    public record EventVendorContractPaymentRequest(
        Guid EventVendorContractId,
        Guid EventVendorContractPaymentTypeId,
        Guid EventVendorContractPaymentStateId,
        decimal DueAmount,
        DateTime DueDate);

    public record TransactionRequest(
        Guid TransactionTypeId,
        decimal Amount,
        DateTime TransactionDate,
        string? Description,
        string? ReferenceNumber);
}