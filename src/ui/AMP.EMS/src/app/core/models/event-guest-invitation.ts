import { EventGuest } from "./event-guest";
import { Guest } from "./guest";
import { EventGuestInvitationRSVP } from "./event-guest-invitation-rsvp";
import { EventInvitation } from "./event-invitation";

export interface EventGuestInvitation {
    id?: string;
    guestId?: string;
    eventInvitationId?: string;
    eventGuest?: EventGuest;
    maxGuests?: number;
    code?: string;
    eventInvitation?: EventInvitation;
    eventGuestInvitationRSVPs?: EventGuestInvitationRSVP[];
}