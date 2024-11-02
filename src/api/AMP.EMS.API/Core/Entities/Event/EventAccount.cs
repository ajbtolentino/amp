using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventAccount : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid AccountId { get; set; }

    public Event Event { get; set; }
    public Account Account { get; set; }
}