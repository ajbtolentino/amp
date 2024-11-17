using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class TimelineController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<Timeline, Guid>(unitOfWork, logger)
{
}