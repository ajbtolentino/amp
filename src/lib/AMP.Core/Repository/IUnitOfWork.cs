using System;

namespace AMP.Core.Repository;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    void BeginTransaction();
    void CommitTransaction();
    void SaveChanges();
}
