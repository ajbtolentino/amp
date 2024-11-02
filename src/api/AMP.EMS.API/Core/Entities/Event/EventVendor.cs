using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendor : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid EventVendorStatusId { get; set; }
    
    public Event Event { get; set; }
    public Vendor Vendor { get; set; }
    public EventVendorStatus EventVendorStatus { get; set; }
}