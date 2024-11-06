import { Base } from "./base.model";
import { Event } from "./event.model";
import { Lookup } from "./lookup-model";
import { Vendor } from "./vendor-model";

export interface EventVendorContract extends Base {
    eventId: string;
    vendorId: string;
    eventVendorContractStateId?: string;
    eventVendorContractPaymentStateId?: string;

    vendor?: Vendor;
    event?: Event;
    eventVendorContractState?: Lookup;
    eventVendorContractPaymentState?: Lookup;
}