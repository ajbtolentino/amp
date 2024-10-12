using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Invitation : BaseEntity<Guid>
{
    public required Guid GuestId { get; set; }
    public required Guid EventId { get; set; }
    public required string Code { get; set; }

    public Event? Event { get; set; }
    public Guest? Guest { get; set; }
    public ICollection<RSVP> RSVPs { get; set; } = [];
}
