using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Guest : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string NickName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public required int Seats { get; set; }

    public virtual Event? Event { get; set; }
    public virtual ICollection<GuestInvitation> GuestInvitations { get; set; } = [];
    public virtual ICollection<GuestRole> GuestRoles { get; set; } = [];
}