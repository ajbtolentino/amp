import { EventGuest } from "./event-guest";

export interface EventInvitation {
    id?: string;
    eventId?: string;
    name?: string;
    description?: string;
    html?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}