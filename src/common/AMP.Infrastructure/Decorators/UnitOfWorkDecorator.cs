using System.Data;
using AMP.Core.Repository;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Decorators;

public class UnitOfWorkDecorator(IUnitOfWork unitOfWork, ILogger<UnitOfWorkDecorator> logger) : IUnitOfWork
{
    private readonly ILogger logger = logger;

    public IDbTransaction BeginTransaction()
    {
        logger.LogInformation($"Decorator - {nameof(BeginTransaction)}");

        return unitOfWork.BeginTransaction();
    }

    public void CommitTransaction()
    {
        logger.LogInformation($"Decorator - {nameof(CommitTransaction)}");

        unitOfWork.CommitTransaction();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        logger.LogInformation($"Decorator - {nameof(Repository)}");

        return unitOfWork.Repository<TEntity>();
    }

    public void RollbackTransaction()
    {
        logger.LogInformation($"Decorator - {nameof(RollbackTransaction)}");

        unitOfWork.RollbackTransaction();
    }

    public void SaveChanges()
    {
        logger.LogInformation($"Decorator - {nameof(SaveChanges)}");

        unitOfWork.SaveChanges();
    }
}
