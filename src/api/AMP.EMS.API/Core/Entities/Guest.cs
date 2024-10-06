using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Guest : BaseEntity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public IReadOnlyCollection<Invitation> Invitations { get; set; } = [];
}
