using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRoleController(IUnitOfWork unitOfWork) : ApiBaseController<EventRole, Guid>(unitOfWork)
    {
    }
}
