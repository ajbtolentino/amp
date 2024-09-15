using AMP.Core.Transaction;

namespace AMP.Core.Repository;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    IDbTransaction BeginTransaction();
    void SaveChanges();
}
