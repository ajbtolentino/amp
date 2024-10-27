namespace AMP.EMS.API.Models;

public class EventInvitationModel
{
    public Guid EventInvitationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<EventGuestInvitationModel> EventGuestInvitations { get; set; } = [];
}