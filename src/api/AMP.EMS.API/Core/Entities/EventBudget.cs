using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventBudget : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }

    // Navigation properties
    public Event Event { get; set; }
}