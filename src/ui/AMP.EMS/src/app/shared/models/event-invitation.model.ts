import { EventGuestInvitation } from "./event-guest-invitation.model";

export interface EventInvitation {
    id?: string;
    eventId?: string;
    name?: string;
    description?: string;
    rsvpDeadline?: Date
    html?: string;
    eventGuestInvitations?: EventGuestInvitation[];
}