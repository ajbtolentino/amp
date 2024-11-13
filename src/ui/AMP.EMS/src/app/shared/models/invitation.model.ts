import { Content } from "./content.model";
import { GuestInvitation } from "./guest-invitation.model";

export interface Invitation {
    id?: string;
    eventId?: string;
    name?: string;
    description?: string;
    contentId?: string;
    rsvpDeadline?: Date
    content?: Content;
    eventGuestInvitations?: GuestInvitation[];
}