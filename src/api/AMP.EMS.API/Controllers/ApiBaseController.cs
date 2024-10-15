using System.Security.Claims;
using AMP.Core.Repository;
using AMP.Infrastructure.Entity;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ApiBaseController<TEntity, TKey>(IUnitOfWork unitOfWork) : ControllerBase
        where TEntity : BaseEntity<TKey>
    {
        protected readonly IUnitOfWork unitOfWork = unitOfWork;
        protected readonly IRepository<TEntity> entityRepository = unitOfWork.Repository<TEntity>();

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            var entities = this.entityRepository.GetAll();

            return Ok(new OkResponse<IEnumerable<TEntity>>(string.Empty) { Data = entities });
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var @event = await this.entityRepository.Get(id);

            return Ok(new OkResponse<TEntity>(string.Empty) { Data = @event });
        }

        [HttpPost]
        protected async Task<IActionResult> Post(TEntity entity)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var newEntity = await this.entityRepository.Add(entity);

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();

                return Ok(new OkResponse<TEntity>(string.Empty) { Data = newEntity });
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();

                return Problem(ex.Message);
            }
        }

        [HttpPut]
        protected async Task<IActionResult> Put(TEntity entity)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var result = this.entityRepository.Update(entity);

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();

                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                unitOfWork.BeginTransaction();

                this.entityRepository.Delete(id);

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();

                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll([FromBody] IEnumerable<TKey> keys)
        {
            try
            {
                unitOfWork.BeginTransaction();

                foreach (var key in keys)
                {
                    this.entityRepository.Delete(key);
                }

                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();

                return Problem(ex.Message);
            }
        }
    }
}