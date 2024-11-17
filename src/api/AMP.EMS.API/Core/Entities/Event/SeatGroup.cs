using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class SeatGroup : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int MaxSeats { get; set; }

    public virtual Event Event { get; set; }
    public virtual ICollection<SeatGroupAttendee> SeatGroupAttendees { get; set; } = [];
}