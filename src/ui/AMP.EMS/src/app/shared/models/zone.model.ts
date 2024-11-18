import { Base, ZoneSeat } from ".";

export interface Zone extends Base {
    eventId?: string;
    name?: string;
    configuration?: string;
    capacity?: number;

    event?: Event;
    zoneSeats?: ZoneSeat[];
}