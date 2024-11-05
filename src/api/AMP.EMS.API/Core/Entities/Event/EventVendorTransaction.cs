using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventOrder : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid TransactionId { get; set; }

    public virtual Event Event { get; set; }
    public virtual Transaction Transaction { get; set; }
}