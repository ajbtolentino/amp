import { Guest } from "./guest-model";
import { Event } from "./event.model";
import { EventGuestInvitation } from "./event-guest-invitation.model";
import { EventGuestRole } from "./event-guest-role.model";

export interface EventGuest {
    id?: string;
    eventId?: string;
    guestId?: string;
    maxGuests?: number;
    guest?: Guest;
    eventGuestInvitations?: EventGuestInvitation[];
    eventGuestRoles?: EventGuestRole[];
}