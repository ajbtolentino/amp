using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Event : FullAuditableEntity<Guid>
{
    public required string Title { get; set; }
    public required Guid EventTypeId { get; set; }
    public Guid? ContentId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int Seats { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual EventType? EventType { get; set; }
    public virtual Content Content { get; set; }
    public virtual ICollection<EventAccount> EventAccounts { get; set; } = [];
    public virtual ICollection<EventVendorTypeBudget> EventVendorTypeBudgets { get; set; } = [];
    public virtual ICollection<Guest> Guests { get; set; } = [];
    public virtual ICollection<Invitation> Invitations { get; set; } = [];
    public virtual ICollection<Role> Roles { get; set; } = [];
    public virtual ICollection<VendorContract> VendorContracts { get; set; } = [];
    public virtual ICollection<EventVendorTransaction> EventVendorTransactions { get; set; } = [];
    public virtual ICollection<VendorContractState> VendorContractStates { get; set; } = [];
    public virtual ICollection<VendorContractPaymentState> VendorContractPaymentStates { get; set; } = [];
    public virtual ICollection<VendorContractPaymentType> VendorContractPaymentTypes { get; set; } = [];
    public virtual ICollection<EventTask> EventTasks { get; set; } = [];
    public virtual ICollection<Zone> Zones { get; set; } = [];
    public virtual ICollection<Timeline> Timelines { get; set; } = [];
}