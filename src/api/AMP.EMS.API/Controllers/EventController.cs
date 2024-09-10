using AMP.Core.DbContext;
using AMP.EMS.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EventController(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Returns all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = this.applicationDbContext.GetAll<Event, Guid>();

            return Ok(todos);
        }

        /// <summary>
        /// Returns event by eventId
        /// </summary>
        /// <param name="eventId">Id of the todo</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{eventId}")]
        public IActionResult Get(Guid eventId)
        {
            var todo = this.applicationDbContext.GetAll<Event, Guid>().FirstOrDefault(e => e.Id == eventId);

            return Ok(todo);
        }

        /// <summary>
        /// Adds a new todo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        /// <summary>
        /// Updates an existing todo
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{eventId}")]
        public IActionResult Put()
        {
            return Ok();
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{eventId}")]
        public IActionResult Delete(Guid eventId)
        {
            return Ok();
        }
    }
}
