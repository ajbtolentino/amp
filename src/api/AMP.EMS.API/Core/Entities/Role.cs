using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Role : Lookup
{
    public Guid EventId { get; set; }
    public Event? Event { get; set; }
    public ICollection<EventGuestRole> EventGuestRoles { get; set; } = [];
}
