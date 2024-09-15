using System;
using AMP.Core.Repository;
using AMP.Core.Transaction;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Decorators;

public class UnitOfWorkDecorator(IUnitOfWork unitOfWork, ILogger<UnitOfWorkDecorator> logger) : IUnitOfWork
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly ILogger logger = logger;

    public IDbTransaction BeginTransaction()
    {
        logger.LogInformation($"Decorator - {nameof(BeginTransaction)}");

        return this.unitOfWork.BeginTransaction();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        logger.LogInformation($"Decorator - {nameof(Repository)}");

        return this.unitOfWork.Repository<TEntity>();
    }

    public void SaveChanges()
    {
        logger.LogInformation($"Decorator - {nameof(SaveChanges)}");

        this.unitOfWork.SaveChanges();
    }
}
