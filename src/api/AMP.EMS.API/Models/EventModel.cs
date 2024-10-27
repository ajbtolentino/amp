namespace AMP.EMS.API.Models;

public class EventModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public Guid EventTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; }

    public int MaxGuests { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }
}