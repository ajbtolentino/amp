using System;

namespace AMP.Shared.Data;

public interface IEntity<T>
{
    T Id {get;set;}
}
