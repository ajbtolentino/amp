using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class VendorContractPaymentController(
    IUnitOfWork unitOfWork,
    ILogger<VendorContractPaymentStateController> logger)
    : ApiBaseController<VendorContractPayment, Guid>(unitOfWork, logger)
{
    [HttpPost("{id:guid}/transaction")]
    public async Task<IActionResult> ContractTransaction(Guid id, [FromBody] PaymentTransactionRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var eventVendorContractPayment = await EntityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventVendorContractPayment);

            var eventVendorContract = await UnitOfWork.Set<VendorContract>()
                .Get(eventVendorContractPayment.VendorContractId);

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

            return Ok(new OkResponse<VendorContractPayment>(string.Empty) { Data = eventVendorContractPayment });
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VendorContractPaymentRequest request)
    {
        return await base.Post(new VendorContractPayment
        {
            VendorContractId = request.VendorContractId,
            VendorContractPaymentTypeId = request.VendorContractPaymentTypeId,
            VendorContractPaymentStateId = request.VendorContractPaymentStateId,
            DueDate = request.DueDate,
            DueAmount = request.DueAmount
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] VendorContractPaymentRequest request)
    {
        var eventVendorContractPayment = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContractPayment);

        eventVendorContractPayment.VendorContractPaymentTypeId = request.VendorContractPaymentTypeId;
        eventVendorContractPayment.VendorContractPaymentStateId = request.VendorContractPaymentStateId;
        eventVendorContractPayment.DueAmount = request.DueAmount;
        eventVendorContractPayment.DueDate = request.DueDate;

        return await base.Put(eventVendorContractPayment);
    }

    public record VendorContractPaymentRequest(
        Guid VendorContractId,
        Guid VendorContractPaymentTypeId,
        Guid VendorContractPaymentStateId,
        decimal DueAmount,
        DateTime DueDate);

    public record PaymentTransactionRequest(
        Guid TransactionTypeId,
        decimal Amount,
        DateTime TransactionDate,
        string? Description,
        string? ReferenceNumber);
}