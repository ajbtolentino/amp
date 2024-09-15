using System;
using AMP.Core.Transaction;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Decorators;

public class DbTransactionDecorator(IDbTransaction dbTransaction, ILogger<DbTransactionDecorator> logger) : IDbTransaction
{
    public void Commit()
    {
        logger.LogInformation($"Decorator - {nameof(Commit)}");
        dbTransaction.Commit();
    }

    public void Dispose()
    {
        logger.LogInformation($"Decorator - {nameof(Dispose)}");
        dbTransaction.Dispose();
    }

    public void Rollback()
    {
        logger.LogInformation($"Decorator - {nameof(Rollback)}");
        dbTransaction.Rollback();
    }
}
