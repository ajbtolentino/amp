using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractPaymentController(
    IUnitOfWork unitOfWork,
    ILogger<EventVendorContractPaymentStateController> logger)
    : ApiBaseController<EventVendorContractPayment, Guid>(unitOfWork, logger)
{
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
}