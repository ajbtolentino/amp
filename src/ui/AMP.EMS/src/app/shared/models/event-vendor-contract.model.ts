import { Base } from "./base.model";
import { EventVendorContractPayment } from "./event-vendor-contract-payment.model";
import { Event } from "./event.model";
import { Lookup } from "./lookup-model";
import { Vendor } from "./vendor-model";

export interface EventVendorContract extends Base {
    eventId: string;
    vendorId: string;
    eventVendorContractStateId?: string;
    amount?: number;
    details?: string;

    vendor?: Vendor;
    event?: Event;
    eventVendorContractState?: Lookup;
    eventVendorContractPayments?: EventVendorContractPayment[];
}