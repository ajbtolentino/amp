using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMP.Infrastructure.Repository;

public class EFRepository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbContext dbContext = dbContext;

    public TEntity Add(TEntity entity)
    {
        var result = this.dbContext.Add(entity).Entity;
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
        var result = this.dbContext.Update<TEntity>(entity).Entity;
        return result;
    }
}
