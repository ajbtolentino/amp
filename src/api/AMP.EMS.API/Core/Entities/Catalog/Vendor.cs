using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Vendor : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string ContactInformation { get; set; } = string.Empty;
    public Guid VendorTypeId { get; set; }

    public virtual VendorType VendorType { get; set; }
    public virtual ICollection<VendorAccount> VendorAccounts { get; set; } = [];
    public virtual ICollection<EventVendorTransaction> EventVendorTransactions { get; set; } = [];
    public virtual ICollection<VendorContract> VendorContracts { get; set; } = [];
}