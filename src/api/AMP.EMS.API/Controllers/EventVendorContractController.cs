using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractController(IUnitOfWork unitOfWork, ILogger<EventVendorContractController> logger)
    : ApiBaseController<EventVendorContract, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventVendorContractRequest request)
    {
        var eventVendorContract = new EventVendorContract
        {
            EventId = request.EventId,
            VendorId = request.VendorId
        };

        if (!request.EventVendorContractStateId.HasValue)
        {
            var contractStates = UnitOfWork.Set<EventVendorContractState>().GetAll();
            eventVendorContract.EventVendorContractStateId = contractStates.FirstOrDefault().Id;
        }

        if (!request.EventVendorContractPaymentStateId.HasValue)
        {
            var paymentStates = UnitOfWork.Set<EventVendorContractPaymentState>().GetAll();
            eventVendorContract.EventVendorContractPaymentStateId = paymentStates.FirstOrDefault().Id;
        }

        return await base.Post(eventVendorContract);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorContractRequest request)
    {
        var eventVendorContract = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContract);

        if (!request.EventVendorContractStateId.HasValue)
        {
            var contractStates = UnitOfWork.Set<EventVendorContractState>().GetAll();
            eventVendorContract.EventVendorContractStateId = contractStates.FirstOrDefault().Id;
        }

        if (!request.EventVendorContractPaymentStateId.HasValue)
        {
            var paymentStates = UnitOfWork.Set<EventVendorContractPaymentState>().GetAll();
            eventVendorContract.EventVendorContractPaymentStateId = paymentStates.FirstOrDefault().Id;
        }

        return await base.Put(eventVendorContract);
    }

    public record EventVendorContractRequest(
        Guid EventId,
        Guid VendorId,
        Guid? EventVendorContractStateId,
        Guid? EventVendorContractPaymentStateId);
}