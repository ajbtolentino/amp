import { EventGuest } from "./event-guest";
import { Guest } from "./guest";
import { Rsvp } from "./rsvp";

export interface EventGuestInvitation {
    id?: string;
    guestId?: string;
    eventInvitationId?: string;
    guest?: Guest;
    maxGuests?: number;
    code?: string;
    rsvps?: Rsvp[];
}