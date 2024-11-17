import { Base } from "./base.model";

export interface SeatGroup extends Base {
    eventId?: string;
    name?: string;
    description?: string;
    maxSeats?: number;

    event?: Event;
}