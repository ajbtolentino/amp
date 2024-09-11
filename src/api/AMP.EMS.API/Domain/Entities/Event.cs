using System;
using AMP.Core.Entity;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Entities;

public class Event : BaseEntity<Guid>
{
    public required string Name { get; set; }
}
