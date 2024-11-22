using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class ZoneSeatController(IUnitOfWork unitOfWork, ILogger<ZoneSeatController> logger)
    : ApiBaseController<ZoneSeat, Guid>(unitOfWork, logger)
{
    public record ZoneSeatRequest(Guid ZoneId, Guid GuestId, Guest? Guest, string Configuration);
}