using System;

namespace AMP.Shared.Handlers;

public interface IHandler<TRequest, TResponse> 
{ 
    TResponse Execute(TRequest request);
}