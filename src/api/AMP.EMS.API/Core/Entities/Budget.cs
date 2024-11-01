using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Budget : FullAuditableEntity<Guid>
{
    public string UserId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation properties
    public Category Category { get; set; }
}