using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitation : FullAuditableEntity<Guid>
{
    public required Guid EventInvitationId { get; set; }
    public int MaxGuests { get; set; }
    public string Code { get; set; }
    
    public List<Guid> EventGuestInvitationRsvps { get; set; } = [];
}