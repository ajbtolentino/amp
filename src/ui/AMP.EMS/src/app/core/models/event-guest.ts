import { Guest } from "./guest";
import { Event } from "./event";

export interface EventGuest {
    id?: string;
    eventId?: string;
    guestId?: string;
    maxGuests?: number;
    eventGuestRoles?: string[];
    eventInvitations?: string[];
}