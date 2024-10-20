import { EventType } from "./event-type";

export interface Event {
    id?: string;
    title?: string;
    eventTypeId?: string;
    eventType?: EventType;
    startDate?: Date;
    endDate?: Date;
    description?: string;
    dateCreated?: Date;
    dateUpdated?: Date;
}