using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractController(IUnitOfWork unitOfWork, ILogger<EventVendorContractController> logger)
    : ApiBaseController<EventVendorContract, Guid>(unitOfWork, logger)
{
    [HttpGet("{id:guid}/payments")]
    public IActionResult GetPayments(Guid id)
    {
        var eventVendorContractPayments = unitOfWork.Set<EventVendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => _.EventVendorContractId == id);

        return Ok(new OkResponse<IEnumerable<EventVendorContractPayment>>(string.Empty)
            { Data = eventVendorContractPayments });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventVendorContractRequest request)
    {
        return await base.Post(new EventVendorContract
        {
            EventId = request.EventId,
            VendorId = request.VendorId,
            Amount = request.Amount ?? 0M,
            Details = request.Details ?? string.Empty,
            EventVendorContractStateId = request.EventVendorContractStateId
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventVendorContractRequest request)
    {
        var eventVendorContract = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContract);
        ArgumentNullException.ThrowIfNull(eventVendorContract.Amount);
        ArgumentNullException.ThrowIfNull(eventVendorContract.Details);

        eventVendorContract.EventVendorContractStateId = request.EventVendorContractStateId;
        eventVendorContract.Amount = request.Amount ?? 0M;
        eventVendorContract.Details = request.Details ?? string.Empty;

        return await base.Put(eventVendorContract);
    }

    public record EventVendorContractRequest(
        Guid EventId,
        Guid VendorId,
        decimal? Amount,
        string? Details,
        Guid? EventVendorContractStateId);
}