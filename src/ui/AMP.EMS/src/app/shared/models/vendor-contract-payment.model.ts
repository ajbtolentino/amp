import { Base } from "./base.model";
import { Lookup } from "./lookup.model";
import { Transaction } from "./transaction.model";
import { VendorContract } from "./vendor-contract.model";

export interface VendorContractPayment extends Base {
    vendorContractId?: string;
    vendorContractPaymentTypeId?: string;
    vendorContractPaymentStateId?: string;
    transactionId?: string;
    dueAmount?: number;
    dueDate?: Date;

    vendorContract?: VendorContract;
    vendorContractPaymentState?: Lookup;
    transaction?: Transaction;
}