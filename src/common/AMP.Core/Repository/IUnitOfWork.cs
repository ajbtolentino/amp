using System.Data;

namespace AMP.Core.Repository;

public interface IUnitOfWork
{
    IRepository<TEntity> Set<TEntity>() where TEntity : class;
    IDbTransaction BeginTransaction();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveChangesAsync();
}