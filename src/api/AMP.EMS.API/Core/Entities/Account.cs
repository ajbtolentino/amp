using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Account : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public Guid AccountTypeId { get; set; }

    // Navigation properties
    public AccountType AccountType { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}