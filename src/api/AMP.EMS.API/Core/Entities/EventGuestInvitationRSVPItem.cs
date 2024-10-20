using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestInvitationRSVPItem : BaseEntity<Guid>
{
    public required Guid EventGuestInvitationRSVPId { get; set; }
    public required string GuestName { get; set; }

    public EventGuestInvitationRSVP? EventGuestInvitationRSVP { get; set; }
}
