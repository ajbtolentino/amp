import { Event } from "./event";
import { Vendor } from "./vendor";

export interface EventVendor {
    id?: string;
    eventId?: string;
    vendorId?: string;
    event?: Event
    vendor?: Vendor;
}