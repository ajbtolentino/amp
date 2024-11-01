using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorAccount : FullAuditableEntity<Guid>
{
    public Guid VendorId { get; set; }
    public Guid AccountId { get; set; }
    public Vendor Vendor { get; set; }
    public Account Account { get; set; }
}