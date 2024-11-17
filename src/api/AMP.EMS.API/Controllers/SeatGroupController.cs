using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class SeatGroupController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<SeatGroup, Guid>(unitOfWork, logger)
{
}