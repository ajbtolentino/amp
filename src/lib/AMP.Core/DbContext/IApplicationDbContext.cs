using System;
using AMP.Core.Entity;

namespace AMP.Core.DbContext;

public interface IApplicationDbContext
{
    IEnumerable<TEntity> GetAll<TEntity, TID>() where TEntity : class, IEntity<TID>;
    TEntity Get<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>;
    TEntity Add<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>;
    TEntity Update<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>;
    void Delete<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>;
    bool Save();
}