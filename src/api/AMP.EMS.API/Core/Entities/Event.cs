using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Event : BaseEntity<Guid>
{
    public required string Title { get; set; }

    public required Guid EventTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public EventType? EventType { get; set; }
    public ICollection<Invitation> Invitations { get; set; } = [];
}
