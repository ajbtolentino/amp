import { Account } from "./account";
import { Vendor } from "./vendor";

export interface VendorAccount {
    id?: string;
    accountId?: string;
    vendorId?: string;

    account?: Account;
    vendor?: Vendor;
}