using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Event : FullAuditableEntity<Guid>
{
    public required string Title { get; set; }

    public required Guid EventTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; }

    public int MaxGuests { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }
    
    public EventType? EventType { get; set; }

    public ICollection<EventAccount> EventAccounts { get; set; }
    public ICollection<EventVendorTypeBudget> EventBudgets { get; set; } = [];
    public ICollection<EventGuest> EventGuests { get; set; } = [];
    public ICollection<EventInvitation> EventInvitations { get; set; } = [];
    public ICollection<Role> Roles { get; set; } = [];
    public ICollection<EventVendor> EventVendors { get; set; } = [];
}
