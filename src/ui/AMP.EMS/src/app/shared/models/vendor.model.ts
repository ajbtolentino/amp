import { Base } from "./base.model";
import { VendorAccount } from "./vendor-account.model";
import { VendorContract } from "./vendor-contract.model";
import { VendorType } from "./vendor-type.model";

export interface Vendor extends Base {
    name?: string;
    description?: string;
    vendorTypeId?: string;
    contactInformation?: string;
    address?: string;

    vendorType?: VendorType;
    vendorContracts?: VendorContract[];
    vendorAccounts?: VendorAccount[];
}