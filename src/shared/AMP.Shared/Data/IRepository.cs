using System;
using AMP.Shared.Data;

namespace AMP.Shared.Data;

public interface IRepository<TEntity, TID> where TEntity : IEntity<TID>
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(TID id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TID id);
}
