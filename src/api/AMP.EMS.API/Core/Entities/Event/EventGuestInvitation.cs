using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitation : FullAuditableEntity<Guid>
{
    public Guid EventGuestId { get; set; }
    public required Guid EventInvitationId { get; set; }
    public int MaxGuests { get; set; }
    public string Code { get; set; }
    public virtual EventGuest? EventGuest { get; set; }
    public virtual EventInvitation? EventInvitation { get; set; }
    public virtual ICollection<EventGuestInvitationRsvp> EventGuestInvitationRsvps { get; set; } = [];
}