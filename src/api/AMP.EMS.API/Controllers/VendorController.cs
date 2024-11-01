using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class VendorController(IUnitOfWork unitOfWork, ILogger<VendorController> logger) : ApiBaseController<Vendor, Guid>(unitOfWork, logger)
{
   public record VendorRequest(Guid EventId, string Name, string Description, string ContactInformation);

   [HttpPost]
   public async Task<IActionResult> Post([FromBody] VendorRequest request)
   {
      try
      {
         unitOfWork.BeginTransaction();

         var vendor = await unitOfWork.Repository<Vendor>().Add(new Vendor
         {
            Description = request.Description,
            Name = request.Name,
            ContactInformation = request.ContactInformation
         });
         
         vendor.EventVendors.Add(new EventVendor()
         {
            EventId = request.EventId,
            VendorId = vendor.Id
         });

         await unitOfWork.SaveChangesAsync();
         await unitOfWork.CommitTransactionAsync();
         
         return Ok(new OkResponse<Vendor>(string.Empty));
      }
      catch (Exception e)
      {
         logger.LogError(e.Message, e);
         await unitOfWork.RollbackTransactionAsync();
         return Problem(e.Message);
      }
   }
}