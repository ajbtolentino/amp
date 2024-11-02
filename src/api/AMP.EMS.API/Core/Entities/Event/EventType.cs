using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventType : LookupEntity<Guid>
{
    public ICollection<Event> Events { get; set; } = [];
    public ICollection<EventTypeRole> EventTypeRoles { get; set; }
}