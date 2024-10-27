import { EventGuestRole } from "./event-guest-role";
import { EventType } from "./event-type";

export interface Event {
    id?: string;
    title?: string;
    eventTypeId?: string;
    eventType?: EventType;
    startDate?: Date;
    endDate?: Date;
    eventRoles?: EventGuestRole[];
    description?: string;
}