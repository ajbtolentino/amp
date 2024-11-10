import { Base } from "./base.model";
import { VendorType } from "./vendor-type.model";

export interface EventVendorTypeBudget extends Base {
    eventId?: string;
    vendorTypeId?: string;
    description?: string;
    amount?: number;

    event?: Event;
    vendorType?: VendorType;
}