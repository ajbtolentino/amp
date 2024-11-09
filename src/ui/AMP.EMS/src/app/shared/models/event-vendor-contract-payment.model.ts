import { Base } from "./base.model";
import { EventVendorContract } from "./event-vendor-contract.model";
import { Lookup } from "./lookup.model";
import { Transaction } from "./transaction.model";

export interface EventVendorContractPayment extends Base {
    eventVendorContractId?: string;
    eventVendorContractPaymentTypeId?: string;
    eventVendorContractPaymentStateId?: string;
    transactionId?: string;
    dueAmount?: number;
    dueDate?: Date;

    eventVendorContract?: EventVendorContract;
    eventVendorContractPaymentState?: Lookup;
    transaction?: Transaction;
}