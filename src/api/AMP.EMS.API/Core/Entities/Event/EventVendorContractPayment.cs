using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class EventVendorContractPayment : FullAuditableEntity<Guid>
{
    public Guid EventVendorContractId { get; set; }
    public Guid EventVendorContractPaymentStateId { get; set; }
    public Guid EventVendorContractPaymentTypeId { get; set; }
    public Guid? TransactionId { get; set; }
    public decimal DueAmount { get; set; }
    public DateTime DueDate { get; set; }

    public virtual EventVendorContract EventVendorContract { get; set; }
    public virtual EventVendorContractPaymentType EventVendorContractPaymentType { get; set; }
    public virtual EventVendorContractPaymentState EventVendorContractPaymentState { get; set; }
    public virtual Transaction Transaction { get; set; }
}