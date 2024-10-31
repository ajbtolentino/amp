using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuest : FullAuditableEntity<Guid>
{
    public required Guid EventId { get; set; }
    public required Guid GuestId { get; set; }
    public required int MaxGuests { get; set; }
    public Event? Event { get; set; }
    public Guest? Guest { get; set; }
    public ICollection<EventGuestInvitation> EventGuestInvitations { get; set; } = [];
    public ICollection<EventGuestRole> EventGuestRoles { get; set; } = [];
}
