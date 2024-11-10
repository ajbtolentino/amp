import { Lookup } from "./lookup.model";

export interface Role extends Lookup {
    eventId?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}