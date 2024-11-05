using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorContractStatus : LookupEntity<Guid>
{
    public virtual ICollection<EventVendorContract> EventTransactions { get; set; } = [];
}