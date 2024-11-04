using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitationRsvpItem: FullAuditableEntity<Guid>
{
    public Guid EventGuestInvitationRsvpId { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual EventGuestInvitationRsvp? EventGuestInvitationRsvp { get; set; }
}