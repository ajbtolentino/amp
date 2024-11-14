import { Guest } from "./guest.model";
import { Role } from "./role.model";

export interface GuestRole {
    id?: string;
    roleId?: string;
    guestId?: string;

    eventGuest?: Guest;
    role?: Role;
}
