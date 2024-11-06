using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class VendorTypeController(IUnitOfWork unitOfWork, ILogger<VendorTypeController> logger)
    : ApiBaseController<VendorType, Guid>(unitOfWork, logger)
{
}