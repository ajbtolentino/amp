using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventOrder : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid ProductId { get; set; }
    public Guid EventTransactionStatusId { get; set; }

    public Event Event { get; set; }
    public Product Product { get; set; }
    public EventOrderStatus EventOrderStatus { get; set; }
}