using AMP.Core.DbContext;
using AMP.Core.Entity;

namespace AMP.Core.Repository;

public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class, IEntity<TID>
{
    private readonly IApplicationDbContext applicationDbContext;

    public Repository(IApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public TEntity Add(TEntity entity)
    {
        return this.applicationDbContext.Add<TEntity, TID>(entity);
    }

    public void Delete(TID id)
    {
        this.applicationDbContext.Delete<TEntity, TID>(id);
    }

    public TEntity Get(TID id)
    {
        return this.applicationDbContext.Get<TEntity, TID>(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return this.applicationDbContext.GetAll<TEntity, TID>();
    }

    public TEntity Update(TEntity entity)
    {
        return this.applicationDbContext.Update<TEntity, TID>(entity);
    }
}
