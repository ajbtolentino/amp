using System;
using AMP.Core.Entity;

namespace AMP.Core.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity Get<TKey>(TKey key);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete<TKey>(TKey id);
}