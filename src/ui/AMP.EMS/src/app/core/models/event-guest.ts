import { Guest } from "./guest";
import { Event } from "./event";
import { EventGuestInvitation } from "./event-guest-invitation";
import { EventGuestRole } from "./event-guest-role";

export interface EventGuest {
    id?: string;
    eventId?: string;
    guestId?: string;
    maxGuests?: number;
    guest?: Guest;
    eventGuestInvitations?: EventGuestInvitation[];
    eventGuestRoles?: EventGuestRole[];
}