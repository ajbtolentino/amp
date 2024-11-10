using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Guest : FullAuditableEntity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string NickName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public virtual ICollection<EventGuest> EventGuests { get; set; } = [];
}



