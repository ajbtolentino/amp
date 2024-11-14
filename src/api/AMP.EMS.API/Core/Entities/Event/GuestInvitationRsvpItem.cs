using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class GuestInvitationRsvpItem : FullAuditableEntity<Guid>
{
    public Guid GuestInvitationRsvpId { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual GuestInvitationRsvp? GuestInvitationRsvp { get; set; }
}