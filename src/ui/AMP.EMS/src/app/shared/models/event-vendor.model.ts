import { Event } from "./event.model";
import { Vendor } from "./vendor-model";

export interface EventVendor {
    id?: string;
    eventId?: string;
    vendorId?: string;
    event?: Event
    vendor?: Vendor;
}