using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitation : BaseEntity<Guid>
{
    public required Guid EventGuestId { get; set; }
    public required Guid EventInvitationId { get; set; }
    public required string Code { get; set; }

    public EventGuest? EventGuest { get; set; }
    public EventInvitation? EventInvitation { get; set; }
    public ICollection<EventGuestInvitationRSVP> EventGuestInvitationRSVPs { get; set; } = [];
}