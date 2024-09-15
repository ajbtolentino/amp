using System;
using AMP.Core.Transaction;
using Microsoft.EntityFrameworkCore.Storage;

namespace AMP.Infrastructure.Transaction;

public class EFDbTransaction(IDbContextTransaction transaction) : IDbTransaction
{
    public void Commit() => transaction.Commit();

    public void Dispose() => transaction.Dispose();

    public void Rollback() => transaction.Rollback();
}
