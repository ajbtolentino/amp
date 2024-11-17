using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class EventTaskController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<EventTask, Guid>(unitOfWork, logger)
{
}