using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class AuthenticatedEventController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IRepository<Event> eventRepository = unitOfWork.Repository<Event>();

        /// <summary>
        /// Returns all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = this.eventRepository.GetAll();

            return Ok(new OkResponse<IEnumerable<Event>>(string.Empty) { Data = events });
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

            return Ok(new OkResponse<Event>(string.Empty) { Data = @event });
        }

        /// <summary>
        /// Adds a new event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Event @event)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var newEvent = this.eventRepository.Add(@event);

                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();

                return Ok(new OkResponse<Event>(string.Empty) { Data = newEvent });
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();

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
            try
            {
                unitOfWork.BeginTransaction();

                var entity = this.eventRepository.Get(@event.Id);
                entity.DateCreated = @event.DateCreated;
                entity.DateUpdated = @event.DateUpdated;
                entity.Name = @event.Name;

                var result = this.eventRepository.Update(entity);

                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();

                return Ok(result);
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();

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
            try
            {
                unitOfWork.BeginTransaction();

                this.eventRepository.Delete(id);

                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();

                return Ok();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();

                return Problem(ex.Message);
            }

        }
    }
}
