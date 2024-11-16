using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;

namespace AMP.EMS.API.Controllers.Payment;

public class AccountController(IUnitOfWork unitOfWork, ILogger<AccountController> logger)
    : ApiBaseController<Account, Guid>(unitOfWork, logger)
{
}