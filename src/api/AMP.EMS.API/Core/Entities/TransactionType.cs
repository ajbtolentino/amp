using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class TransactionType : Lookup
{
    // Navigation properties
    public ICollection<Transaction> Transactions { get; set; }
}