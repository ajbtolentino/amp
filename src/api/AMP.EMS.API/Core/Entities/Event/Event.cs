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

    public virtual EventType? EventType { get; set; }

    public virtual ICollection<EventAccount> EventAccounts { get; set; } = [];
    public virtual ICollection<EventVendorTypeBudget> EventBudgets { get; set; } = [];
    public virtual ICollection<EventGuest> EventGuests { get; set; } = [];
    public virtual ICollection<EventInvitation> EventInvitations { get; set; } = [];
    public virtual ICollection<Role> Roles { get; set; } = [];
    public virtual ICollection<EventVendorContract> EventVendorContracts { get; set; } = [];
    public virtual ICollection<EventVendorTransaction> EventVendorTransactions { get; set; } = [];
    public virtual ICollection<EventVendorContractState> EventVendorContractStates { get; set; } = [];
}