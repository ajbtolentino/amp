using System;
using AMP.Shared.Core;

namespace AMP.Shared.Infrastructure;

public interface IAMPDbContext
{
    IEnumerable<TEntity> GetAll<TEntity, TID>();
    TEntity Get<TEntity, TID>(TID id) where TEntity : IEntity<TID>;
    void Add<TEntity, TID>(TEntity entity) where TEntity : IEntity<TID>;
    void Update<TEntity, TID>(TEntity entity) where TEntity : IEntity<TID>;
    void Delete<TEntity, TID>(TID id);
    bool SaveChanges();
}