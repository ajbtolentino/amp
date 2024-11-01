using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Account : FullAuditableEntity<Guid>
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public AccountType Type { get; set; }
    public decimal Balance { get; set; } = 0.00M;

    // Navigation properties
    public ICollection<Transaction> Transactions { get; set; }
}