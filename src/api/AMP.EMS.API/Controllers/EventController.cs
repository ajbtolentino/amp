using AMP.Core.Repository;
using AMP.EMS.API.Entities;
using AMP.EMS.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IRepository<EMSDbContext, Event> eventRepository;

        public EventController(IRepository<EMSDbContext, Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        /// <summary>
        /// Returns all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = this.eventRepository.GetAll();

            return Ok(events);
        }

        /// <summary>
        /// Returns event by id
        /// </summary>
        /// <param name="id">Id of the todo</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var @event = this.eventRepository.Get(id);

            return Ok(@event);
        }

        /// <summary>
        /// Adds a new event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Event @event)
        {
            @event.Id = Guid.NewGuid();

            var newEvent = this.eventRepository.Add(@event);

            return Ok(newEvent);
        }

        /// <summary>
        /// Updates an existing event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
