using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorContractPaymentType : LookupEntity<Guid>
{
    public Guid EventId { get; set; }

    public Event Event { get; set; }
    public virtual ICollection<VendorContractPayment> VendorContractPayments { get; set; }
}