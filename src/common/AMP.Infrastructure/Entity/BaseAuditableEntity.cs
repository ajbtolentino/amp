using System;
using AMP.Core.Entity;

namespace AMP.Infrastructure.Entity;

public class BaseAuditableEntity : IAuditableEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
    public string UpdatedBy { get; set; } = string.Empty;
}
