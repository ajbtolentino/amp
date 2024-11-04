using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendor : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid EventVendorStatusId { get; set; }

    public virtual Event Event { get; set; }
    public virtual Vendor Vendor { get; set; }
    public virtual EventVendorStatus EventVendorStatus { get; set; }
}