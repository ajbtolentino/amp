using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Transaction : FullAuditableEntity<Guid>
{
    public Guid? DebitAccountId { get; set; }
    public Guid? CreditAccountId { get; set; }
    public Guid TransactionTypeId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Account DebitAccount { get; set; }
    public Account CreditAccount { get; set; }
    public TransactionType TransactionType { get; set; }
}