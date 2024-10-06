using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IUnitOfWork unitOfWork) : ApiBaseController<Event, Guid>(unitOfWork)
    {
        public record EventData(string Name);

        [HttpPost]
        public IActionResult Post([FromBody] EventData data)
        {
            return base.Post(new Event
            {
                Name = data.Name,
                DateCreated = DateTime.Now
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] EventData data)
        {
            return base.Put(new Event
            {
                Id = id,
                Name = data.Name,
                DateUpdated = DateTime.Now
            });
        }
    }
}
