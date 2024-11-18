using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class ZoneController(IUnitOfWork unitOfWork, ILogger<ZoneController> logger)
    : ApiBaseController<Zone, Guid>(unitOfWork, logger)
{
}