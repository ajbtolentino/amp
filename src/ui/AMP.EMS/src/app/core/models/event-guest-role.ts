import { Event } from "./event";
import { EventGuest } from "./event-guest";
import { Role } from "./role";

export interface EventGuestRole {
    id?: string;
    roleId?: string;
    eventGuestId?: string;
    eventGuest?: EventGuest;
    role?: Role;
}
