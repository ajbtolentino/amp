import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventGuestInvitation, EventInvitation, Guest } from '@shared/models';
import { Observable } from 'rxjs';

export interface EventGuestInvitationResponse {
    guest: Guest;
    eventGuestInvitation: EventGuestInvitation;
    eventInvitation: EventInvitation;
}

@Injectable({
    providedIn: 'root'
})
export class EventGuestInvitationService extends BaseApiService {
    getByEventGuestIds = (eventGuestIds: string[]): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`api/eventguestinvitation/getbyeventguestids`, { params: { eventGuestIds: eventGuestIds } });
    }

    getByEventInvitationIds = (eventInvitationIds: string[]): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`api/eventguestinvitation/getbyeventinvitationids`, { params: { eventInvitationIds: eventInvitationIds } });
    }

    add = (eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPost(`api/eventguestinvitation/`, eventGuestInvitation);
    }

    update = (id: string, eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPut(`api/eventguestinvitation/${id}`, eventGuestInvitation);
    }

    delete = (id: string): Observable<EventGuestInvitation> => {
        return this.httpDelete(`api/eventguestinvitation/${id}`);
    }

    rsvp = (code: string): Observable<EventGuestInvitation> => {
        return this.httpGet(`api/eventguestinvitation/${code}/rsvp`);
    }
}