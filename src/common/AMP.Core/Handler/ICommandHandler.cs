using System;

namespace AMP.Core.Handler;

public interface ICommandHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
{
    bool CanCommand(TRequest request);
}