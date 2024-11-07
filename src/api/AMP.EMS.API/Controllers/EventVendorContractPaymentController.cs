using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class EventVendorContractPaymentController(
    IUnitOfWork unitOfWork,
    ILogger<EventVendorContractPaymentStateController> logger)
    : ApiBaseController<EventVendorContractPayment, Guid>(unitOfWork, logger)
{
}