using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace AMP.Infrastructure.Repository;

public class EFUnitOfWork(DbContext dbContext, IServiceProvider serviceProvider) : IUnitOfWork
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class => serviceProvider.GetRequiredService<EFRepository<TEntity>>();

    public IDbTransaction BeginTransaction() => dbContext.Database.BeginTransaction().GetDbTransaction();

    public void CommitTransaction() => dbContext.Database.CurrentTransaction.Commit();

    public void RollbackTransaction() => dbContext.Database.CurrentTransaction.Rollback();

    public void SaveChanges() => dbContext.SaveChanges();
}
