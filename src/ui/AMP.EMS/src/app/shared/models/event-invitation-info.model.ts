export interface EventInvitationInfo {
    eventInvitationId?: string;
    name?: string;
    description?: string;
    eventGuestInvitations?: EventGuestInvitationInfo[];
}

export interface EventGuestInvitationInfo {
    eventGuestInvitationId?: string;
    maxGuests?: number;
    code?: string;
    rsvps?: EventGuestInvitationRsvpInfo[];
}

export interface EventGuestInvitationRsvpInfo {
    eventGuestInvitationRsvpId?: string;
    response?: string;
    guestNames?: string[];
}