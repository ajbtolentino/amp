using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Account : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public string AccountNumber { get; set; }
    public Guid AccountTypeId { get; set; }

    // Navigation properties
    public virtual AccountType AccountType { get; set; }
    public virtual ICollection<EventAccount> EventAccounts { get; set; } = [];
    public virtual ICollection<Transaction> DebitTransactions { get; set; } = [];
    public virtual ICollection<Transaction> CreditTransactions { get; set; } = [];
    public virtual ICollection<VendorAccount> VendorAccounts { get; set; } = [];
}