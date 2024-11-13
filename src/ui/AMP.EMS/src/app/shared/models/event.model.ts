import { EventType } from "./event-type.model";
import { GuestRole } from "./guest-role.model";

export interface Event {
    id?: string;
    title?: string;
    eventTypeId?: string;
    eventType?: EventType;
    startDate?: Date;
    endDate?: Date;
    seats?: number;
    eventRoles?: GuestRole[];
    description?: string;
}