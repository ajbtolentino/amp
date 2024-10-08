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

    public async Task CommitTransactionAsync()
    {
        // logger.LogInformation($"Committing transaction...");

        await unitOfWork.CommitTransactionAsync();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        logger.LogInformation($"Accessing {typeof(TEntity).Name} repository...");

        return unitOfWork.Repository<TEntity>();
    }

    public async Task RollbackTransactionAsync()
    {
        // logger.LogInformation($"Rolling back transaction...");

        await unitOfWork.RollbackTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await unitOfWork.SaveChangesAsync();
    }
}
