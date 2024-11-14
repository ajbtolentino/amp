import { GuestInvitationRsvpItem } from "./guest-invitation-rsvp-item.model";

export interface GuestInvitationRsvp {
    id?: string;
    guestInvitationId?: string;
    guestNames?: string[];
    details?: string;
    response?: 'ACCEPT' | 'DECLINE' | undefined;
    dateCreated?: Date;
    guestInvitationRsvpItems?: GuestInvitationRsvpItem[];
}