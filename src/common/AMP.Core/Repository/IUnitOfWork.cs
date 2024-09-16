
using System.Data;

namespace AMP.Core.Repository;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    IDbTransaction BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    void SaveChanges();
}
