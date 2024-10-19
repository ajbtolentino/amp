import { EventGuest } from "./event-guest";
import { Guest } from "./guest";

export interface EventGuestInvitation {
    id?: string;
    eventInvitationId?: string;
    guestId?: string;
    guest?: Guest;
    code?: string;
    maxGuests?: number;
    limitedView?: boolean;
    dateCreated?: Date;
    dateUpdated?: Date;
}