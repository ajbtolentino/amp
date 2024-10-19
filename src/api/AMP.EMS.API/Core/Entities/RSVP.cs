using System;
using AMP.EMS.API.Core.Constants;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class RSVP : BaseEntity<Guid>
{
    public required Guid EventGuestInvitationId { get; set; }
    public RSVPResponse Response { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public EventGuestInvitation? EventGuestInvitation { get; set; }
}
