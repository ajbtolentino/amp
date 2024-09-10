using System;
using AMP.Core.DbContext;
using AMP.Core.Entity;

namespace AMP.Core.Repository;

public interface IRepository<TEntity, TID> where TEntity : IEntity<TID>
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(TID id);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TID id);
}