export interface EventGuestInvitationRSVP {
    id?: string;
    eventGuestInvitationId?: string;
    eventGuestInvitationRSVPItems?: EventGuestInvitationRSVPItem[];
    phoneNumber?: string;
    response?: 'ACCEPT' | 'DECLINE'
}

export interface EventGuestInvitationRSVPItem {
    id?: string;
    name?: string;
}