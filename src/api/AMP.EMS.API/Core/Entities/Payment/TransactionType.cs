using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class TransactionType : LookupEntity<Guid>
{
    // Navigation properties
    public virtual ICollection<Transaction> Transactions { get; set; } = [];
}