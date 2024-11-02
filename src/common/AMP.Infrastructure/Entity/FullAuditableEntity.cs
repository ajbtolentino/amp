using AMP.Core.Entity;
using MongoDB.Bson.Serialization.Attributes;

namespace AMP.Infrastructure.Entity;

public class FullAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
{
    public string CreatedBy { get; set; } = string.Empty;
    public string UpdatedBy { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? DateUpdated { get; set; }
}