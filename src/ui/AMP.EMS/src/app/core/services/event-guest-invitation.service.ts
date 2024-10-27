import { lastValueFrom, Observable } from 'rxjs';
import { EventInvitation } from '../models/event-invitation';
import { BaseApiService } from './base.api.service';
import { Guest } from '../models/guest';
import { EventGuestInvitation } from '../models/event-guest-invitation';

export interface GuestInvitationResponse {
    guest: Guest;
    eventGuestInvitation: EventGuestInvitation;
    eventInvitation: EventInvitation;
}

export class EventGuestInvitationService extends BaseApiService {
    rsvp = (code: string): Observable<GuestInvitationResponse> => {
        return this.httpGet(`api/eventguestinvitation/${code}/rsvp`);
    }
}