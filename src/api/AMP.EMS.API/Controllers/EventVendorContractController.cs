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
            VendorId = request.VendorId,
            EventVendorContractStateId = request.EventVendorContractStatusId
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorContractRequest data)
    {
        var eventTransaction = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventTransaction);


        return await base.Put(eventTransaction);
    }

    public record EventVendorContractRequest(Guid EventId, Guid VendorId, Guid EventVendorContractStatusId);
}