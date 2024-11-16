using AMP.Core.Repository;
using AMP.Infrastructure.Entity;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ApiBaseController<TEntity, TKey>(IUnitOfWork unitOfWork, ILogger logger) : ControllerBase
    where TEntity : BaseEntity<TKey>
{
    protected readonly IRepository<TEntity> EntityRepository = unitOfWork.Set<TEntity>();
    protected readonly IUnitOfWork UnitOfWork = unitOfWork;

    [HttpGet]
    public virtual IActionResult GetAll()
    {
        var entities = EntityRepository.GetAll();

        return Ok(new OkResponse<IEnumerable<TEntity>>(string.Empty) { Data = entities });
    }

    [HttpGet]
    [Route(nameof(GetByIds))]
    public virtual IActionResult GetByIds([FromQuery] List<TKey> ids)
    {
        var entities = EntityRepository.GetAll().Where(entity => ids.Contains(entity.Id));

        return Ok(new OkResponse<IEnumerable<TEntity>>(string.Empty) { Data = entities });
    }

    [HttpGet]
    [Route("{id}")]
    public virtual async Task<IActionResult> Get(TKey id)
    {
        var @event = await EntityRepository.Get(id);

        return Ok(new OkResponse<TEntity>(string.Empty) { Data = @event });
    }

    [HttpPost]
    protected async Task<IActionResult> Post(TEntity entity)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var newEntity = await EntityRepository.Add(entity);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<TEntity>(string.Empty) { Data = newEntity });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    protected async Task<IActionResult> Put(TEntity entity)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var result = EntityRepository.Update(entity);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public virtual async Task<IActionResult> Delete(TKey id)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            EntityRepository.Delete(id);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll([FromBody] IEnumerable<TKey> keys)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            foreach (var key in keys) EntityRepository.Delete(key);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }
}