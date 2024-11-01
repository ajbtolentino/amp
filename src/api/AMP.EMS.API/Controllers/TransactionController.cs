using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class TransactionController(IUnitOfWork unitOfWork, ILogger<TransactionController> logger) : ApiBaseController<Transaction, Guid>(unitOfWork, logger)
{
    
}