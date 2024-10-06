using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(IUnitOfWork unitOfWork) : ApiBaseController<Guest, Guid>(unitOfWork)
    {
        public record GuestData(string FirstName, string LastName);

        [HttpPost]
        public IActionResult Post([FromBody] GuestData data)
        {
            return base.Post(new Guest
            {
                FirstName = data.FirstName,
                LastName = data.LastName
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] GuestData data)
        {
            return base.Put(new Guest
            {
                Id = id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateUpdated = DateTime.Now
            });
        }
    }
}
