import { Guest } from "./guest";

export interface Invitation {
    id?: string;
    eventId?: string;
    guestId?: string;
    guest?: Guest;
    code?: string;
    maxGuests?: number;
    limitedView?: boolean;
    dateCreated?: Date;
    dateUpdated?: Date;
}