
import { Base } from "./base.model";
import { Guest } from "./guest.model";
import { SeatGroup } from "./seat-group.model";

export interface SeatGroupAttendee extends Base {
    seatGroupId?: string;
    guestId?: string;

    seatGroup?: SeatGroup;
    guest?: Guest;
}