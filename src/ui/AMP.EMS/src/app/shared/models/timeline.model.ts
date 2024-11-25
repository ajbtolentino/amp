import { Base } from "./base.model";

export interface Timeline extends Base {
    eventId?: string;
    name?: string;
    description?: string;
    startDate?: Date | undefined | null;
    endDate?: Date | undefined | null;

    event?: Event;
}