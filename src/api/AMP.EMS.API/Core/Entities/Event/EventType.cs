using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventType : LookupEntity<Guid>
{
    public virtual ICollection<Event> Events { get; set; } = [];
    public virtual ICollection<EventTypeRole> EventTypeRoles { get; set; }
}