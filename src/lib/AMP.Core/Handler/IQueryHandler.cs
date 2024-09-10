using System;

namespace AMP.Core.Handler;

public interface IQueryHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
{
    bool CanQuery(TRequest request);
}
