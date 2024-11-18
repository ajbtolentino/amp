import { Base, Guest, Zone } from ".";

export interface ZoneSeat extends Base {
    zoneId?: string;
    guestId?: string;

    zone?: Zone;
    guest?: Guest;
}