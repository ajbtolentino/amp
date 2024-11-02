using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitationRsvp : FullAuditableEntity<Guid>
{
    public Guid EventGuestInvitationId { get; set; }
    public required RsvpResponse Response { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public EventGuestInvitation? EventGuestInvitation { get; set; }
    public ICollection<EventGuestInvitationRsvpItem> EventGuestInvitationRsvpItems { get; set; } = [];
}
