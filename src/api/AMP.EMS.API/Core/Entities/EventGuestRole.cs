using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventGuestRole : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
