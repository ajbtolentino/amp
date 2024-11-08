import { Content } from "./content.model";
import { EventGuestInvitation } from "./event-guest-invitation.model";

export interface EventInvitation {
    id?: string;
    eventId?: string;
    name?: string;
    description?: string;
    contentId?: string;
    rsvpDeadline?: Date
    content?: Content;
    eventGuestInvitations?: EventGuestInvitation[];
}