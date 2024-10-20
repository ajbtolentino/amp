import { Guest } from "./guest";
import { Event } from "./event";
import { EventGuestInvitation } from "./event-guest-invitation";
import { EventGuestRole } from "./event-guest-role";
import { EventRole } from "./event-role";
import { EventInvitation } from "./event-invitation";

export interface EventGuest {
    id?: string;
    eventId?: string;
    guestId?: string;
    guest?: Guest;
    event?: Event;
    maxGuests?: number;
    eventGuestRoles?: EventGuestRole[];
    eventGuestInvitations?: EventGuestInvitation[];
}