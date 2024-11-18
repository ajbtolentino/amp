using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Zone : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }
    public string Configuration { get; set; }

    public virtual Event Event { get; set; }
    public ICollection<ZoneSeat> ZoneSeats { get; set; } = [];
}