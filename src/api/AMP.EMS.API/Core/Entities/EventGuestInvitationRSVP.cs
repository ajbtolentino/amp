using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitationRsvp : FullAuditableEntity<Guid>
{
    public required RsvpResponse Response { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public List<string> GuestNames { get; set; } = [];
}
