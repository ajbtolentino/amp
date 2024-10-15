using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(IUnitOfWork unitOfWork) : ApiBaseController<Guest, Guid>(unitOfWork)
    {
        public record GuestData(string FirstName, string LastName);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GuestData data)
        {
            return await base.Post(new Guest
            {
                FirstName = data.FirstName,
                LastName = data.LastName
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GuestData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.FirstName = data.FirstName;
            entity.LastName = data.LastName;

            return await base.Put(entity);
        }
    }
}
