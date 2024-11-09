import { Base } from "./base.model";
import { EventVendorContract } from "./event-vendor-contract.model";
import { EventVendor } from "./event-vendor.model";
import { VendorAccount } from "./vendor-account.model";
import { VendorType } from "./vendor-type.model";

export interface Vendor extends Base {
    name?: string;
    description?: string;
    vendorTypeId?: string;
    contactInformation?: string;
    address?: string;

    vendorType?: VendorType;
    eventVendorContracts?: EventVendorContract[];
    eventVendors?: EventVendor[];
    vendorAccounts?: VendorAccount[];
}