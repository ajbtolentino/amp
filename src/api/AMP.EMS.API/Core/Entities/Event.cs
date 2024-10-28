using AMP.Infrastructure.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AMP.EMS.API.Core.Entities;

public class Event : FullAuditableEntity<Guid>
{
    public required string Title { get; set; }

    public required Guid EventTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; }

    public int MaxGuests { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }
}
