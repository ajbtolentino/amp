using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class GuestRole : FullAuditableEntity<Guid>
{
    public Guid RoleId { get; set; }
    public Guid GuestId { get; set; }
    public virtual Role? Role { get; set; }
    public virtual Guest? Guest { get; set; }
}