using System;

namespace AMP.Shared.Handlers;

public interface IQueryHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
{
    bool CanQuery(TRequest request);
}
