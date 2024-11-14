using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class VendorContractPayment : FullAuditableEntity<Guid>
{
    public Guid VendorContractId { get; set; }
    public Guid VendorContractPaymentStateId { get; set; }
    public Guid VendorContractPaymentTypeId { get; set; }
    public Guid? TransactionId { get; set; }
    public decimal DueAmount { get; set; }
    public DateTime DueDate { get; set; }

    public virtual VendorContract VendorContract { get; set; }
    public virtual VendorContractPaymentType VendorContractPaymentType { get; set; }
    public virtual VendorContractPaymentState VendorContractPaymentState { get; set; }
    public virtual Transaction Transaction { get; set; }
}