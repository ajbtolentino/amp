using System;

namespace AMP.Core.Entity;

public interface IAuditableEntity
{
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
