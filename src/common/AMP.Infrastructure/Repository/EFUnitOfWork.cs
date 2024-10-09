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

    public async Task CommitTransactionAsync() => await dbContext.Database.CurrentTransaction.CommitAsync();

    public async Task RollbackTransactionAsync() => await dbContext.Database.CurrentTransaction.RollbackAsync();

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
}
