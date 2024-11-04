using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class ProductCategory : LookupEntity<Guid>
{
    public virtual ICollection<Product> Products { get; set; } = [];
}