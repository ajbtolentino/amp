using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers.Payment;

public class AccountTypeController(IUnitOfWork unitOfWork, ILogger<AccountController> logger)
    : ApiBaseController<AccountType, Guid>(unitOfWork, logger)
{
}