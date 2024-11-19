import { Base, Guest, Zone } from ".";
import { Configuration } from "./configuration.model";

export interface ZoneSeat extends Base {
    zoneId?: string;
    guestId?: string;
    configuration?: string;
    config?: Configuration;

    zone?: Zone;
    guest?: Guest;
}