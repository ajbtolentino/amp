using System;
using AMP.Core.Entity;

namespace AMP.Core.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> Get<TKey>(TKey key);
    Task<TEntity> Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete<TKey>(TKey id);
}