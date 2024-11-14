import { Base } from "./base.model";
import { Event } from "./event.model";
import { Lookup } from "./lookup.model";
import { VendorContractPayment } from "./vendor-contract-payment.model";
import { Vendor } from "./vendor.model";

export interface VendorContract extends Base {
    eventId: string;
    vendorId: string;
    vendorContractStateId?: string;
    amount?: number;
    details?: string;

    vendor?: Vendor;
    event?: Event;
    vendorContractState?: Lookup;
    vendorContractPayments?: VendorContractPayment[];
}