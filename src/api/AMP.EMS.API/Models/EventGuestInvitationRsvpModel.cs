using AMP.EMS.API.Core.Constants;

namespace AMP.EMS.API.Models;

public class EventGuestInvitationRsvpModel
{
    public Guid EventGuestInvitationRsvpId { get; set; }
    public RsvpResponse Response { get; set; }
    public DateTime DateCreated { get; set; }
    public IEnumerable<string> GuestNames { get; set; }
}