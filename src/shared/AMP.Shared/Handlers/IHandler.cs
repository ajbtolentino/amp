using System;

namespace AMP.Shared.Handlers;

public interface IHandler { }

public interface IHandler<TRequest, TResponse> : IHandler
{
    bool CanHandle(TRequest request);
    TResponse Handle(TRequest request);
}