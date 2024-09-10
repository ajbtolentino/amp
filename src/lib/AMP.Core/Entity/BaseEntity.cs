namespace AMP.Core.Entity;

public class BaseEntity<TID> : IEntity<TID>
{
    public TID Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
