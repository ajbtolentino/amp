using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorContractPaymentState : LookupEntity<Guid>
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }
    public virtual ICollection<VendorContractPayment> VendorContractPayments { get; set; }
}