import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Guest, EventGuestInvitation, EventInvitation } from '@shared/models';

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