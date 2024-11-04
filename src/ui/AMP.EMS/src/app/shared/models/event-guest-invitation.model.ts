import { EventGuest } from "./event-guest.model";
import { EventGuestInvitationRsvp } from "./event-guest-invitation-rsvp.model";
import { EventInvitation } from "./event-invitation.model";

export interface EventGuestInvitation {
    id?: string;
    eventGuestId?: string;
    eventInvitationId?: string;
    maxGuests?: number;
    code?: string;
    eventInvitation?: EventInvitation;
    eventGuestInvitationRsvps?: EventGuestInvitationRsvp[];
    eventGuest?: EventGuest;
    dateCreated?: Date;
}