namespace AMP.EMS.API.Models;

public class EventGuestModel
{
    public Guid GuestId { get; set; }
    public Guid EventGuestId { get; set; }
    public Guid EventId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public string NickName { get; set; } = string.Empty;

    public int MaxGuests { get; set; }

    public IEnumerable<EventGuestRoleModel> EventGuestRoles { get; set; } = [];
    public IEnumerable<EventGuestInvitationModel> EventGuestInvitations { get; set; } = [];
}