using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventRole : BaseEntity<Guid>
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
