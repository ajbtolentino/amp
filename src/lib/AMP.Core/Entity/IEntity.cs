using System;

namespace AMP.Core.Entity;

public interface IEntity<T>
{
    T Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
