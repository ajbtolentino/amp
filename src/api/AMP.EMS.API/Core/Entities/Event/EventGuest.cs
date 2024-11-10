using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuest : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required Guid GuestId { get; set; }
    public required int Seats { get; set; }
    public virtual Event? Event { get; set; }
    public virtual Guest? Guest { get; set; }
    public virtual ICollection<EventGuestInvitation> EventGuestInvitations { get; set; } = [];
    public virtual ICollection<EventGuestRole> EventGuestRoles { get; set; } = [];
}