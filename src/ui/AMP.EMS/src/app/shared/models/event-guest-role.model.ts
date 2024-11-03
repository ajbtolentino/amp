import { Event } from "./event.model";
import { EventGuest } from "./event-guest.model";
import { Role } from "./role.model";

export interface EventGuestRole {
    id?: string;
    roleId?: string;
    eventGuestId?: string;
    eventGuest?: EventGuest;
    role?: Role;
}
