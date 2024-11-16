import { Account } from "./account.model";
import { Base } from "./base.model";
import { Event } from "./event.model";

export interface EventAccount extends Base {
    eventId?: string;
    accountId?: string;

    event?: Event;
    account?: Account;
}