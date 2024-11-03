import { Account } from "./account.model";
import { Vendor } from "./vendor-model";

export interface VendorAccount {
    id?: string;
    accountId?: string;
    vendorId?: string;

    account?: Account;
    vendor?: Vendor;
}