import { EventVendor } from "./event-vendor.model";
import { VendorAccount } from "./vendor-account.model";

export interface Vendor {
    id?: string;
    name?: string;
    description?: string;
    conactInformation?: string;

    eventVendors?: EventVendor[];
    vendorAccounts?: VendorAccount[];
}