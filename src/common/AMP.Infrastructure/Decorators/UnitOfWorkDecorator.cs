using System.Data;
using AMP.Core.Repository;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Decorators;

public class UnitOfWorkDecorator(IUnitOfWork unitOfWork, ILogger<UnitOfWorkDecorator> logger) : IUnitOfWork
{
    private readonly ILogger logger = logger;

    public IDbTransaction BeginTransaction()
    {
        // logger.LogInformation($"Starting transaction...");

        return unitOfWork.BeginTransaction();
    }

    public void CommitTransaction()
    {
        // logger.LogInformation($"Committing transaction...");

        unitOfWork.CommitTransaction();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        logger.LogInformation($"Accessing {typeof(TEntity).Name} repository...");

        return unitOfWork.Repository<TEntity>();
    }

    public void RollbackTransaction()
    {
        // logger.LogInformation($"Rolling back transaction...");

        unitOfWork.RollbackTransaction();
    }

    public void SaveChanges()
    {
        // logger.LogInformation($"Saving changes...");

        unitOfWork.SaveChanges();
    }
}
