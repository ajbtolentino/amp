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
        return await base.Post(new EventVendorContract
        {
            EventId = request.EventId,
            VendorId = request.VendorId
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorContractRequest request)
    {
        var eventVendorContract = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContract);
        ArgumentNullException.ThrowIfNull(request.EventVendorContractStateId);
        ArgumentNullException.ThrowIfNull(request.EventVendorContractPaymentStateId);

        eventVendorContract.EventVendorContractStateId = request.EventVendorContractStateId.Value;
        eventVendorContract.EventVendorContractPaymentStateId = request.EventVendorContractPaymentStateId.Value;

        return await base.Put(eventVendorContract);
    }

    public record EventVendorContractRequest(
        Guid EventId,
        Guid VendorId,
        Guid? EventVendorContractStateId,
        Guid? EventVendorContractPaymentStateId);
}