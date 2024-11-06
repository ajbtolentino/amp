using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractStatusController(IUnitOfWork unitOfWork, ILogger<EventVendorContractController> logger)
    : ApiBaseController<EventVendorContract, Guid>(unitOfWork, logger)
{
}