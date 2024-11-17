using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class SeatGroupAttendee : FullAuditableEntity<Guid>
{
    public Guid SeatGroupId { get; set; }
    public Guid GuestId { get; set; }

    public virtual SeatGroup SeatGroup { get; set; }
    public virtual Guest Guest { get; set; }
}