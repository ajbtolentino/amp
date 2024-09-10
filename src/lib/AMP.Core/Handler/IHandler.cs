using System;

namespace AMP.Core.Handler;

public interface IHandler<TRequest, TResponse> 
{ 
    TResponse Execute(TRequest request);
}