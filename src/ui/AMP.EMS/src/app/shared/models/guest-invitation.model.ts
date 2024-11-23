import { Guest } from "./guest.model";
import { Invitation } from "./invitation.model";

export interface GuestInvitation {
    id?: string;
    guestId?: string;
    invitationId?: string;
    maxGuests?: number;
    code?: string;
    invitation?: Invitation;
    // guestInvitationRsvps?: GuestInvitationRsvp[];
    guest?: Guest;
    data?: any;
    dateCreated?: Date;
}