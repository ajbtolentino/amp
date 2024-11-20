using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class GuestInvitationRsvp : FullAuditableEntity<Guid>
{
    public Guid GuestInvitationId { get; set; }
    public required RsvpResponse Response { get; set; }
    public string Data { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public virtual GuestInvitation? GuestInvitation { get; set; }
    public virtual ICollection<GuestInvitationRsvpItem> GuestInvitationRsvpItems { get; set; } = [];
}