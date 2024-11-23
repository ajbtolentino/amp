using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class GuestInvitation : FullAuditableEntity<Guid>
{
    public Guid GuestId { get; set; }
    public required Guid InvitationId { get; set; }
    public int Seats { get; set; }
    public string Code { get; set; }
    public string Data { get; set; }
    public virtual Guest? Guest { get; set; }
    public virtual Invitation? Invitation { get; set; }
}