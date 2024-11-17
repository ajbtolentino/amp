using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class SeatGroupAttendeeController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<SeatGroupAttendee, Guid>(unitOfWork, logger)
{
}