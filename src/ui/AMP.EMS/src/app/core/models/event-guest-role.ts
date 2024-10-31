import { Event } from "./event";
import { EventRole } from "./event-role";

export interface EventGuestRole {
    id?: string;
    eventRoleId?: string;
    eventGuestId?: string;
    event?: Event;
    eventRole?: EventRole;
}
