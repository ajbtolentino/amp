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
    add = (eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPost(`api/eventguestinvitation/`, eventGuestInvitation);
    }

    update = (id: string, eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPut(`api/eventguestinvitation/${id}`, eventGuestInvitation);
    }

    delete = (id: string): Observable<EventGuestInvitation> => {
        return this.httpDelete(`api/eventguestinvitation/${id}`);
    }

    rsvp = (code: string): Observable<EventGuestInvitationResponse> => {
        return this.httpGet(`api/eventguestinvitation/${code}/rsvp`);
    }
}