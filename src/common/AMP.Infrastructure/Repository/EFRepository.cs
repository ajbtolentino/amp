using AMP.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace AMP.Infrastructure.Repository;

public class EFRepository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : class
{
    public async Task<TEntity> Add(TEntity entity) => (await dbContext.AddAsync(entity)).Entity;

    public void Delete<TKey>(TKey key) => dbContext.Remove(dbContext.Find<TEntity>(key)!);

    public async Task<TEntity> Get<TKey>(TKey key) => await dbContext.FindAsync<TEntity>(key);

    public IQueryable<TEntity> GetAll() => dbContext.Set<TEntity>();

    public TEntity Update(TEntity entity) => dbContext.Update(entity).Entity;
}
