using System;
using AMP.Core.Entity;

namespace AMP.EMS.API.Entities;

public class Event : BaseEntity<Guid>
{
    public required string Name { get; set; }
}
