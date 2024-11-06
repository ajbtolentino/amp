using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorContract : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid EventVendorContractStateId { get; set; }
    public Guid EventVendorContractPaymentStateId { get; set; }

    public virtual Event Event { get; set; }
    public virtual Vendor Vendor { get; set; }
    public virtual EventVendorContractState EventVendorContractState { get; set; }
    public virtual EventVendorContractPaymentState EventVendorContractPaymentState { get; set; }
}