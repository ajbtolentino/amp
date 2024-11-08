using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class ContentController(IUnitOfWork unitOfWork, ILogger<ContentController> logger)
    : ApiBaseController<Content, Guid>(unitOfWork, logger)
{
}