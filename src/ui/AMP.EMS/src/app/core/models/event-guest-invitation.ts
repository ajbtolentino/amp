import { EventGuest } from "./event-guest";
import { EventGuestInvitationRsvp } from "./event-guest-invitation-rsvp";

export interface EventGuestInvitation {
    eventGuestId?: string;
    eventInvitationId?: string;
    maxGuests?: number;
    code?: string;
    eventGuestInvitationRsvps?: EventGuestInvitationRsvp[];
    eventGuest?: EventGuest;
}