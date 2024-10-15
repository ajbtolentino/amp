using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuest : BaseEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required Guid GuestId { get; set; }

    public Event? Event { get; set; }
    public Guest? Guest { get; set; }
}
