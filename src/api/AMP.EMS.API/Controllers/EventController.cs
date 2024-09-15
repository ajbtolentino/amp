using AMP.Core.Repository;
using AMP.EMS.API.Entities;
using AMP.EMS.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IRepository<Event> eventRepository = unitOfWork.Repository<Event>();

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
            using var transaction = this.unitOfWork.BeginTransaction();

            try
            {
                var newEvent = this.eventRepository.Add(@event);
                this.unitOfWork.SaveChanges();

                transaction.Commit();

                return Ok(newEvent);
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Event @event)
        {
            using var transaction = this.unitOfWork.BeginTransaction();

            try
            {
                var entity = this.eventRepository.Get(@event.Id);
                entity.DateCreated = @event.DateCreated;
                entity.DateUpdated = @event.DateUpdated;
                entity.Name = @event.Name;

                var result = this.eventRepository.Update(entity);
                this.unitOfWork.SaveChanges();

                transaction.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return Problem(ex.Message);
            }
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
            using var transaction = this.unitOfWork.BeginTransaction();

            try
            {
                this.eventRepository.Delete(id);
                this.unitOfWork.SaveChanges();

                transaction.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return Problem(ex.Message);
            }

        }
    }
}
