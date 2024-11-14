using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Invitation : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public Guid? ContentId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? RsvpDeadline { get; set; }

    public virtual Event? Event { get; set; }
    public virtual Content? Content { get; set; }
    public virtual ICollection<GuestInvitation> GuestInvitations { get; set; } = [];
}