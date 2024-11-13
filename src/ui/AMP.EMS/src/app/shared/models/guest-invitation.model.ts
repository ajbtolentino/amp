import { EventGuestInvitationRsvp } from "./event-guest-invitation-rsvp.model";
import { Guest } from "./guest.model";
import { Invitation } from "./invitation.model";

export interface GuestInvitation {
    id?: string;
    guestId?: string;
    eventInvitationId?: string;
    maxGuests?: number;
    code?: string;
    eventInvitation?: Invitation;
    eventGuestInvitationRsvps?: EventGuestInvitationRsvp[];
    guest?: Guest;
    dateCreated?: Date;
}