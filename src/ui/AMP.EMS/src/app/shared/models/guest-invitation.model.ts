import { Guest } from "./guest.model";
import { Invitation } from "./invitation.model";

export interface GuestInvitation {
    id?: string;
    guestId?: string;
    invitationId?: string;
    seats?: number;
    code?: string;
    invitation?: Invitation;
    guest?: Guest;
    data?: any;
}