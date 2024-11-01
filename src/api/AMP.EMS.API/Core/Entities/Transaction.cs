using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Transaction : FullAuditableEntity<Guid>
{
    public Guid? AccountId { get; set; }
    public Guid TransactionTypeId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Account Account { get; set; }
    public TransactionType TransactionType { get; set; }
}