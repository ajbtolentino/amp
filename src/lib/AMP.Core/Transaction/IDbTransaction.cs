using System;

namespace AMP.Core.Transaction;

public interface IDbTransaction : IDisposable
{
    void Commit();
    void Rollback();
}
