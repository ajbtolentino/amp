using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class GuestController(IUnitOfWork unitOfWork) : ApiBaseController<Guest, Guid>(unitOfWork)
    {
        public record GuestData(string FirstName, string LastName);

        [HttpGet]
        public new IActionResult GetAll()
        {
            return base.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GuestData data)
        {
            return await base.Post(new Guest
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateCreated = DateTime.Now
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GuestData data)
        {
            return await base.Put(new Guest
            {
                Id = id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateUpdated = DateTime.Now
            });
        }
    }
}
