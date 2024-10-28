export interface EventGuestInvitationRsvp {
    id?: string;
    eventGuestInvitationId?: string;
    guestNames?: string[];
    phoneNumber?: string;
    response?: 'ACCEPT' | 'DECLINE'
}