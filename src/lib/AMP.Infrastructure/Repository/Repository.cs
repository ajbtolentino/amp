using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMP.Infrastructure.Repository;

public class Repository<TDbContext, TEntity> : IRepository<TDbContext, TEntity>
    where TDbContext : DbContext
    where TEntity : class
{
    private readonly TDbContext dbContext;

    public Repository(TDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public TEntity Add(TEntity entity)
    {
        var result = this.dbContext.Add(entity).Entity;
        this.dbContext.SaveChanges();
        return result;
    }

    public void Delete<TKey>(TKey key)
    {
        var entity = this.Get(key);
        if (entity != null) this.dbContext.Remove(entity);
    }

    public TEntity Get<TKey>(TKey key)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return dbContext.Find<TEntity>(key);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public IEnumerable<TEntity> GetAll()
    {
        return this.dbContext.Set<TEntity>();
    }

    public TEntity Update(TEntity entity)
    {
        return this.dbContext.Update<TEntity>(entity).Entity;
    }
}
