using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Content : FullAuditableEntity<Guid>
{
    public string HtmlContent { get; set; }

    public virtual ICollection<Event> Events { get; set; } = [];
    public virtual ICollection<Invitation> Invitations { get; set; } = [];
}