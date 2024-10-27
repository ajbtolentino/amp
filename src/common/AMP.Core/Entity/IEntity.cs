using System;

namespace AMP.Core.Entity;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
