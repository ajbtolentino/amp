using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventTask : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public required string Description { get; set; }
    public EventTaskState State { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }

    public virtual Event Event { get; set; }
}