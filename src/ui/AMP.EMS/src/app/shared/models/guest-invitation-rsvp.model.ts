
export interface GuestInvitationRsvp {
    guestNames?: string[];
    details?: string;
    response?: 'ACCEPT' | 'DECLINE' | undefined;
}