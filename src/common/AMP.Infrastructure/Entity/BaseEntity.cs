using AMP.Core.Entity;

namespace AMP.Infrastructure.Entity;

public class BaseEntity<TKey> : IEntity<TKey>
{
    public required TKey Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
