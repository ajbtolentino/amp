using System;
using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Guest : BaseEntity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string NickName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<EventInvitation> Invitations { get; set; } = [];
}
