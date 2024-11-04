using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventInvitation : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Html { get; set; } = string.Empty;
    public virtual Event? Event { get; set; }
    public virtual ICollection<EventGuestInvitation> EventGuestInvitations { get; set; } = [];
}