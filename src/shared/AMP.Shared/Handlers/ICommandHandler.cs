using System;

namespace AMP.Shared.Handlers;

public interface ICommandHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
{
    bool CanCommand(TRequest request);
}