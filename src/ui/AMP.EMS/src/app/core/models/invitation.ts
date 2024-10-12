import { Guest } from "./guest";

export interface Invitation {
    id?: string;
    eventId?: string;
    guestId?: string;
    guest?: Guest;
    code?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}