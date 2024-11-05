using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class VendorController(IUnitOfWork unitOfWork, ILogger<VendorController> logger)
    : ApiBaseController<Vendor, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VendorRequest request)
    {
        return await base.Post(new Vendor
        {
            Name = request.Name,
            Description = request.Description,
            ContactInformation = request.ContactInformation,
            Address = request.Address
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] VendorRequest request)
    {
        var vendor = await entityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(vendor);

        vendor.Name = request.Name;
        vendor.ContactInformation = request.ContactInformation;
        vendor.Description = request.Description;
        vendor.Address = request.Address;

        return await base.Put(vendor);
    }

    public record VendorRequest(
        Guid EventId,
        string Name,
        string Description,
        string Address,
        string ContactInformation);
}