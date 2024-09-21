using System;

namespace AMP.Core.Entity;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
