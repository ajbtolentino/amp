import { Base } from "./base.model";

export interface EventTask extends Base {
    eventId?: string;
    description?: string;
    state?: 'NotStarted' | 'InProgress' | 'Completed';
    dateStarted?: Date;
    dateCompleted?: Date;

    event?: Event;
}