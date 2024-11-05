using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventTransactionController(IUnitOfWork unitOfWork, ILogger<EventTransactionController> logger)
    : ApiBaseController<EventVendorContract, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventTransactionRequest data)
    {
        return await base.Post(new EventVendorContract());
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventTransactionRequest data)
    {
        var eventTransaction = await entityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventTransaction);


        return await base.Put(eventTransaction);
    }

    public record EventTransactionRequest(Guid EventId, Guid ProductId);
}