import { EventVendor } from "./eventVendor";
import { VendorAccount } from "./vendorAccount";

export interface Vendor {
    id?: string;
    name?: string;
    description?: string;
    conactInformation?: string;

    eventVendors?: EventVendor[];
    vendorAccounts?: VendorAccount[];
}