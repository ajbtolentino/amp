using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorStatus : LookupEntity<Guid>
{
    public virtual ICollection<EventVendor> EventVendors { get; set; } = [];
}