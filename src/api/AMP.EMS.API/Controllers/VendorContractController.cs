using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class VendorContractController(IUnitOfWork unitOfWork, ILogger<VendorContractController> logger)
    : ApiBaseController<VendorContract, Guid>(unitOfWork, logger)
{
    [HttpGet(nameof(GetByVendorIds))]
    public IActionResult GetByVendorIds([FromQuery] IEnumerable<Guid> vendorIds)
    {
        var eventVendorContracts = UnitOfWork.Set<VendorContract>().GetAll().AsNoTracking()
            .Where(_ => vendorIds.Contains(_.VendorId));

        return Ok(new OkResponse<IEnumerable<VendorContract>>(string.Empty)
            { Data = eventVendorContracts });
    }

    [HttpGet("{id:guid}/payments")]
    public IActionResult GetPayments(Guid id)
    {
        var eventVendorContractPayments = UnitOfWork.Set<VendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => _.VendorContractId == id);

        return Ok(new OkResponse<IEnumerable<VendorContractPayment>>(string.Empty)
            { Data = eventVendorContractPayments });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VendorContractRequest request)
    {
        return await base.Post(new VendorContract
        {
            EventId = request.EventId,
            VendorId = request.VendorId,
            Amount = request.Amount ?? 0M,
            Details = request.Details ?? string.Empty,
            VendorContractStateId = request.VendorContractStateId
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] VendorContractRequest request)
    {
        var eventVendorContract = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventVendorContract);
        ArgumentNullException.ThrowIfNull(eventVendorContract.Amount);
        ArgumentNullException.ThrowIfNull(eventVendorContract.Details);

        eventVendorContract.VendorContractStateId = request.VendorContractStateId;
        eventVendorContract.Amount = request.Amount ?? 0M;
        eventVendorContract.Details = request.Details ?? string.Empty;

        return await base.Put(eventVendorContract);
    }

    public record VendorContractRequest(
        Guid EventId,
        Guid VendorId,
        decimal? Amount,
        string? Details,
        Guid? VendorContractStateId);
}