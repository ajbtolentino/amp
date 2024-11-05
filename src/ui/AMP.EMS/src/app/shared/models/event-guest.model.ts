import { EventGuestInvitation } from "./event-guest-invitation.model";
import { EventGuestRole } from "./event-guest-role.model";
import { Guest } from "./guest-model";

export interface EventGuest {
    id?: string;
    eventId?: string;
    guestId?: string;
    seats?: number;
    guest?: Guest;
    eventGuestInvitations?: EventGuestInvitation[];
    eventGuestRoles?: EventGuestRole[];
}