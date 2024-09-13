using AMP.Core.Repository;
using AMP.EMS.API.Entities;
using AMP.EMS.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IRepository<Event> eventRepository;

        public EventController(IRepository<Event> eventRepository)
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
        /// <param name="event"></param>
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
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Event @event)
        {
            var entity = this.eventRepository.Get(@event.Id);
            entity.DateCreated = @event.DateCreated;
            entity.DateUpdated = @event.DateUpdated;
            entity.Name = @event.Name;

            var result = this.eventRepository.Update(entity);

            return Ok(result);
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
            this.eventRepository.Delete(id);
            return Ok();
        }
    }
}
