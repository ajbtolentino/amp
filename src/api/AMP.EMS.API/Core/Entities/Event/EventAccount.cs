using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventAccount : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid AccountId { get; set; }

    public virtual Event Event { get; set; }
    public virtual Account Account { get; set; }
}