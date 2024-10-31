using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestRole : FullAuditableEntity<Guid>
{
    public Guid EventRoleId { get; set; }
    public Guid EventGuestId { get; set; }
    public EventRole? EventRole { get; set; }
    public EventGuest? EventGuest {get;set;}
}