using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class ZoneSeat : FullAuditableEntity<Guid>
{
    public Guid ZoneId { get; set; }
    public Guid GuestId { get; set; }
    public string Configuration { get; set; }

    public virtual Zone Zone { get; set; }
    public virtual Guest Guest { get; set; }
}