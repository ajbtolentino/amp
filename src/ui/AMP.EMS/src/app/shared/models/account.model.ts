import { Base } from "./base.model";
import { Lookup } from "./lookup.model";

export interface Account extends Base {
    name?: string;
    accountNumber?: string;
    accountTypeId?: string;

    accountType?: Lookup;
}