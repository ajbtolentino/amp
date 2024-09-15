using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Infrastructure.Repository;

public class EFUnitOfWork(DbContext dbContext, IServiceProvider serviceProvider) : IUnitOfWork
{
    private readonly DbContext dbContext = dbContext;
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public void BeginTransaction()
    {
        this.dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        this.dbContext.Database.CommitTransaction();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        return this.serviceProvider.GetRequiredService<IRepository<TEntity>>();
    }

    public void SaveChanges()
    {
        this.dbContext.SaveChanges();
    }
}
