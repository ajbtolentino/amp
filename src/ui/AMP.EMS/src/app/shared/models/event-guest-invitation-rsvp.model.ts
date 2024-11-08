import { EventGuestInvitationRsvpItem } from "./event-guest-invitation-rsvp-item.model";

export interface EventGuestInvitationRsvp {
    id?: string;
    eventGuestInvitationId?: string;
    guestNames?: string[];
    phoneNumber?: string;
    response?: 'ACCEPT' | 'DECLINE' | undefined;
    dateCreated?: Date;
    eventGuestInvitationRsvpItems?: EventGuestInvitationRsvpItem[];
}