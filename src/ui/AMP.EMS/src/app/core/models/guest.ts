import { EventGuestInvitation } from "./event-guest-invitation";

export interface Guest {
    id?: string;
    eventId?: string;
    firstName?: string;
    lastName?: string;
    nickName?: string;
    maxGuests?: number;
    eventRoles?: string[];
    guestInvitations?: EventGuestInvitation[];
    phoneNumber?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}