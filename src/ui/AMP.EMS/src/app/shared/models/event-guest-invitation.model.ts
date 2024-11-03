import { EventGuest } from "./event-guest.model";
import { EventGuestInvitationRsvp } from "./event-guest-invitation-rsvp.model";

export interface EventGuestInvitation {
    id?: string;
    eventGuestId?: string;
    eventInvitationId?: string;
    maxGuests?: number;
    code?: string;
    eventGuestInvitationRsvps?: EventGuestInvitationRsvp[];
    eventGuest?: EventGuest;
}