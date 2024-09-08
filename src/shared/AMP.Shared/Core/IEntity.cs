using System;

namespace AMP.Shared.Core;

public interface IEntity<T>
{
    T Id {get;set;}
}
