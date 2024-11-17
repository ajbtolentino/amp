import { Base } from "./base.model";

export interface Timeline extends Base {
    eventId?: string;
    name?: string;
    description?: string;
    startDate?: Date;
    endDate?: Date;

    event?: Event;
}