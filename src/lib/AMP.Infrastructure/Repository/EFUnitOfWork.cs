using AMP.Core.Repository;
using AMP.Core.Transaction;
using AMP.Infrastructure.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Infrastructure.Repository;

public class EFUnitOfWork(DbContext dbContext, IServiceProvider serviceProvider) : IUnitOfWork
{
    public IDbTransaction BeginTransaction() => serviceProvider.GetRequiredService<IDbTransaction>();

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class => serviceProvider.GetRequiredService<EFRepository<TEntity>>();

    public void SaveChanges() => dbContext.SaveChanges();
}
