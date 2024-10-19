using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitation : BaseEntity<Guid>
{
    public required Guid GuestId { get; set; }
    public required Guid EventInvitationId { get; set; }
    public required string Code { get; set; }
    public required int MaxGuests { get; set; }
    public required bool LimitedView { get; set; }

    public EventInvitation? EventInvitation { get; set; }
    public Guest? Guest { get; set; }
    public ICollection<RSVP> RSVPs { get; set; } = [];
}
