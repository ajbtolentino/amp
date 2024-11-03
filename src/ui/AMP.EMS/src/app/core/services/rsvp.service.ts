import { lastValueFrom, Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';
import { Injectable } from '@angular/core';
import { EventGuestInvitationRsvp } from '@shared/models';

@Injectable({
    providedIn: 'root'
})
export class RsvpService extends BaseApiService {
    add = (rsvp: EventGuestInvitationRsvp): Observable<EventGuestInvitationRsvp> => {
        return this.httpPost(`api/rsvp`, rsvp);
    }
}