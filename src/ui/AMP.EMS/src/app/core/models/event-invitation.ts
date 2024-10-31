import { EventGuestInvitation } from "./event-guest-invitation";

export interface EventInvitation {
    id?: string;
    eventId?: string;
    name?: string;
    description?: string;
    html?: string;
    eventGuestInvitations?: EventGuestInvitation[];
}