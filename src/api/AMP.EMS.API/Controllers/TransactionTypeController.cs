using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers;

public class TransactionTypeController(IUnitOfWork unitOfWork, ILogger<TransactionTypeController> logger)
    : ApiBaseController<TransactionType, Guid>(unitOfWork, logger)
{
}