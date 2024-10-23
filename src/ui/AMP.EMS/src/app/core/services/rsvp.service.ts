import { lastValueFrom } from 'rxjs';
import { BaseService } from './base.service';
import { EventGuestInvitationRSVP } from '../models/event-guest-invitation-rsvp';

export class RsvpService extends BaseService {
    add = async (rsvp: EventGuestInvitationRSVP) => {
        return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/rsvp`, rsvp, { headers: this.headers }));
    }
}