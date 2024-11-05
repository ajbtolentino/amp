using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorContractState : LookupEntity<Guid>
{
    public Guid EventId { get; set; }

    public Event Event { get; set; }
    public virtual ICollection<EventVendorContract> EventVendorContracts { get; set; } = [];
}