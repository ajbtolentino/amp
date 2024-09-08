using System;

namespace AMP.Shared.Handlers;

public interface IHandlerResolver
{
    IHandler<TRequest, TResponse> Resolve<TRequest, TResponse>(TRequest request);
}
