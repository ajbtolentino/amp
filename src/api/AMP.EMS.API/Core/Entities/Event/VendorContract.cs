using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorContract : FullAuditableEntity<Guid>
{
    public Guid EventId { get; set; }
    public Guid VendorId { get; set; }
    public Guid? VendorContractStateId { get; set; }
    public Guid? VendorContractPaymentStateId { get; set; }
    public string Details { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 0M;

    public virtual Event Event { get; set; }
    public virtual Vendor Vendor { get; set; }
    public virtual VendorContractState VendorContractState { get; set; }
    public virtual ICollection<VendorContractPayment> VendorContractPayments { get; set; }
}