namespace AMP.Infrastructure.Entity;

public class LookupEntity<TKey> : FullAuditableEntity<TKey>
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}