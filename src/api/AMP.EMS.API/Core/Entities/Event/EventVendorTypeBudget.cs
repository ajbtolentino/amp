using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorTypeBudget : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorTypeId { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }

    // Navigation properties
    public virtual Event Event { get; set; }
    public virtual VendorType VendorType { get; set; }
}