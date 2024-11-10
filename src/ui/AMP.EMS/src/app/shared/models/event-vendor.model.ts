import { Base } from "./base.model";
import { Event } from "./event.model";
import { Lookup } from "./lookup.model";
import { Vendor } from "./vendor.model";

export interface EventVendor extends Base {
    id?: string;
    eventId?: string;
    vendorId?: string;
    event?: Event
    vendor?: Vendor;
    eventVendorContractState?: Lookup;
    eventVendorContractPaymentState?: Lookup;
}