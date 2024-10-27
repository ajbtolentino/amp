using AMP.Infrastructure.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AMP.EMS.API.Core.Entities;

public class EventType : FullAuditableEntity<Guid>
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
