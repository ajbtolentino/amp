using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestRole : BaseEntity<Guid>
{
    public required Guid EventGuestId { get; set; }
    public required Guid EventRoleId { get; set; }

    public EventGuest? EventGuest { get; set; }
    public EventRole? EventRole { get; set; }
}
