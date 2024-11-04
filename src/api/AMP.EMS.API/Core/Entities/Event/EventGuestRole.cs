using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestRole : FullAuditableEntity<Guid>
{
    public Guid RoleId { get; set; }
    public Guid EventGuestId { get; set; }
    public virtual Role? Role { get; set; }
    public virtual EventGuest? EventGuest {get;set;}
}