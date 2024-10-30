import { lastValueFrom, Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';
import { EventGuestInvitationRsvp } from '../models/event-guest-invitation-rsvp';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class RsvpService extends BaseApiService {
    add = (rsvp: EventGuestInvitationRsvp): Observable<EventGuestInvitationRsvp> => {
        return this.httpPost(`api/rsvp`, rsvp);
    }
}