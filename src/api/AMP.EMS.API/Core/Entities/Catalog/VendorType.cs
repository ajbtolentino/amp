using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorType : LookupEntity<Guid>
{
    public virtual ICollection<Vendor> Vendors { get; set; } = [];
    public virtual ICollection<EventVendorTypeBudget> EventVendorTypeBudgets { get; set; } = [];
}