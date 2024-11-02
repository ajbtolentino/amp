using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorType : LookupEntity<Guid>
{
    public ICollection<Vendor> Vendors { get; set; } = [];
    public ICollection<EventVendorTypeBudget> EventVendorTypeBudgets { get; set; } = [];
}