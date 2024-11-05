using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class Product : FullAuditableEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ProductTypeId { get; set; }
    public decimal Price { get; set; }

    public virtual ProductType ProductType { get; set; }
}