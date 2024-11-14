using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class VendorContractPaymentStateController(
    IUnitOfWork unitOfWork,
    ILogger<VendorContractPaymentStateController> logger)
    : ApiBaseController<VendorContractPaymentState, Guid>(unitOfWork, logger)
{
}