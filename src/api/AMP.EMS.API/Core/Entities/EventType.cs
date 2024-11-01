using AMP.Infrastructure.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AMP.EMS.API.Core.Entities;

public class EventType : Lookup
{
    public ICollection<Event> Events { get; set; } = [];
}