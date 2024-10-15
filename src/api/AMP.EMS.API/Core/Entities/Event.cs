using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Event : BaseEntity<Guid>
{
    public required string Title { get; set; }

    public required Guid EventTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; }

    public int MaxGuests { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public EventType? EventType { get; set; }
    public ICollection<EventInvitation> Invitations { get; set; } = [];
    public ICollection<EventGuest> Guests { get; set; } = [];
}
