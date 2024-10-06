using AMP.Core.Repository;
using AMP.Infrastructure.Entity;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TEntity, TKey>(IUnitOfWork unitOfWork) : ControllerBase
        where TEntity : BaseEntity<TKey>
    {
        protected readonly IUnitOfWork unitOfWork = unitOfWork;
        protected readonly IRepository<TEntity> entityRepository = unitOfWork.Repository<TEntity>();

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = this.entityRepository.GetAll();

            return Ok(new OkResponse<IEnumerable<TEntity>>(string.Empty) { Data = entities });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var @event = this.entityRepository.Get(id);

            return Ok(new OkResponse<TEntity>(string.Empty) { Data = @event });
        }

        [HttpPost]
        protected IActionResult Post(TEntity entity)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var newEntity = this.entityRepository.Add(entity);

                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();

                return Ok(new OkResponse<TEntity>(string.Empty) { Data = newEntity });
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();

                return Problem(ex.Message);
            }
        }

        [HttpPut]
        protected IActionResult Put(TEntity entity)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var result = this.entityRepository.Update(entity);

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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                unitOfWork.BeginTransaction();

                this.entityRepository.Delete(id);

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