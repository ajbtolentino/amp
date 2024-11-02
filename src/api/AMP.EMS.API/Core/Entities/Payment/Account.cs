using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Account : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public string AccountNumber { get; set; }
    public Guid AccountTypeId { get; set; }

    // Navigation properties
    public AccountType AccountType { get; set; }
    public ICollection<EventAccount> EventAccounts { get; set; } = [];
    public ICollection<Transaction> DebitTransactions { get; set; } = [];
    public ICollection<Transaction> CreditTransactions { get; set; } = [];
    public ICollection<VendorAccount> VendorAccounts { get; set; } = [];
}