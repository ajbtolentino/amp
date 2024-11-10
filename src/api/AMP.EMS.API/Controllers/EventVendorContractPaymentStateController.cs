using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractPaymentStateController(
    IUnitOfWork unitOfWork,
    ILogger<EventVendorContractPaymentStateController> logger)
    : ApiBaseController<EventVendorContractPaymentState, Guid>(unitOfWork, logger)
{
}