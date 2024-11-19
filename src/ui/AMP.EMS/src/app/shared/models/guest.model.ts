import { GuestInvitation } from "./guest-invitation.model";
import { GuestRole } from "./guest-role.model";

export interface Guest {
    id?: string;
    eventId?: string;
    firstName?: string;
    lastName?: string;
    nickName?: string;
    phoneNumber?: string;
    guestId?: string;
    seats?: number;
    guest?: Guest;

    eventGuestInvitations?: GuestInvitation[];
    eventGuestRoles?: GuestRole[];
}