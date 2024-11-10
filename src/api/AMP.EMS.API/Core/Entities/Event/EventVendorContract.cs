using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorContract : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid? EventVendorContractStateId { get; set; }
    public Guid? EventVendorContractPaymentStateId { get; set; }
    public string Details { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 0M;

    public virtual Event Event { get; set; }
    public virtual Vendor Vendor { get; set; }
    public virtual EventVendorContractState EventVendorContractState { get; set; }
    public virtual ICollection<EventVendorContractPayment> EventVendorContractPayments { get; set; }
}