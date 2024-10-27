using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuest : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required Guid GuestId { get; set; }
    public required int MaxGuests { get; set; }
    public List<Guid> EventGuestRoles { get; set; } = [];
    public List<Guid> EventInvitations { get; set; } = [];
    public List<Guid> EventGuestInvitations { get; set; } = [];
}
