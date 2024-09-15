using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMP.Infrastructure.Repository;

public class EFRepository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : class
{
    public TEntity Add(TEntity entity) => dbContext.Add(entity).Entity;

    public void Delete<TKey>(TKey key) => dbContext.Remove(dbContext.Find<TEntity>(key)!);

    public TEntity Get<TKey>(TKey key) => dbContext.Find<TEntity>(key);

    public IEnumerable<TEntity> GetAll() => dbContext.Set<TEntity>().AsNoTracking();

    public TEntity Update(TEntity entity) => dbContext.Update<TEntity>(entity).Entity;
}
