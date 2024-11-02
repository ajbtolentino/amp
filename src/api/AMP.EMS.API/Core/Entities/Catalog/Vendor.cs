using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Vendor : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ContactInformation { get; set; }
    public Guid VendorTypeId { get; set; }

    public VendorType VendorType { get; set; }
    public ICollection<EventVendor> EventVendors { get; set; } = [];
    public ICollection<VendorAccount> VendorAccounts { get; set; } = [];
}