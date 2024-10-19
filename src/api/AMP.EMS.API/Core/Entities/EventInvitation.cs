using System.Collections.ObjectModel;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventInvitation : BaseEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Html { get; set; } = string.Empty;

    public Event? Event { get; set; }

    public Collection<EventGuestInvitation> EventGuestInvitations { get; set; } = [];
}
