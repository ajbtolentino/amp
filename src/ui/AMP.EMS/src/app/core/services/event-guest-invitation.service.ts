import { Observable } from 'rxjs';
import { EventInvitation } from '../models/event-invitation';
import { BaseApiService } from './base.api.service';
import { Guest } from '../models/guest';
import { EventGuestInvitation } from '../models/event-guest-invitation';
import { Injectable } from '@angular/core';

export interface EventGuestInvitationResponse {
    guest: Guest;
    eventGuestInvitation: EventGuestInvitation;
    eventInvitation: EventInvitation;
}

@Injectable({
    providedIn: 'root'
})
export class EventGuestInvitationService extends BaseApiService {
    rsvp = (code: string): Observable<EventGuestInvitationResponse> => {
        return this.httpGet(`api/eventguestinvitation/${code}/rsvp`);
    }
}