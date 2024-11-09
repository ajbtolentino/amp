import { EventGuestInvitation } from "./event-guest-invitation.model";

export interface Guest {
    id?: string;
    eventId?: string;
    firstName?: string;
    lastName?: string;
    nickName?: string;
    maxGuests?: number;
    eventRoles?: string[];
    eventGuestInvitations?: EventGuestInvitation[];
    phoneNumber?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}