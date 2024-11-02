using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventTypeRole : LookupEntity<Guid>
{
    public Guid EventTypeId { get; set; }
    public EventType EventType { get; set; }
}