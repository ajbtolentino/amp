using System;

namespace AMP.Core.Handler;

public interface IHandlerResolver
{
    IHandler<TRequest, TResponse> Resolve<TRequest, TResponse>(TRequest request);
}
