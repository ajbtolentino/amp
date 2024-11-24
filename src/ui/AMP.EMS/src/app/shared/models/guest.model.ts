import { GuestInvitation } from "./guest-invitation.model";
import { GuestRole } from "./guest-role.model";

export interface Guest {
    id?: string;
    eventId?: string;
    salutation?: string;
    firstName?: string;
    lastName?: string;
    middleName?: string;
    suffix?: string;
    nickName?: string;
    phoneNumber?: string;
    guestId?: string;
    guest?: Guest;

    guestInvitations?: GuestInvitation[];
    guestRoles?: GuestRole[];
}