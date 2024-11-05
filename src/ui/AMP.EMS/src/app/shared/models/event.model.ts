import { EventGuestRole } from "./event-guest-role.model";
import { EventType } from "./event-type.model";

export interface Event {
    id?: string;
    title?: string;
    eventTypeId?: string;
    eventType?: EventType;
    startDate?: Date;
    endDate?: Date;
    seats?: number;
    eventRoles?: EventGuestRole[];
    description?: string;
}