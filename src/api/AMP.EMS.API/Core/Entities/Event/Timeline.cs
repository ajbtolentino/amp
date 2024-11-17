using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Timeline : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public virtual Event Event { get; set; }
}