namespace AMP.EMS.API.Models;

public class EventGuestInvitationModel
{
    public Guid EventGuestInvitationId { get; set; }
    public string Code { get; set; }
    public int MaxGuests { get; set; }
    public IEnumerable<EventGuestInvitationRsvpModel> Rsvps { get; set; } = [];
}