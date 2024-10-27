import { EventGuestInvitationRsvp } from "./event-guest-invitation-rsvp";

export interface EventGuestInvitation {
    invitationId?: string;
    maxGuests?: number;
    code?: string;
    eventGuestInvitationRsvps?: EventGuestInvitationRsvp[];
}