using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class VendorContractStateController(IUnitOfWork unitOfWork, ILogger<VendorContractController> logger)
    : ApiBaseController<VendorContractState, Guid>(unitOfWork, logger)
{
}