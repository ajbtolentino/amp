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
        return this.httpGet(`eventguestinvitation/getbyeventguestids`, { params: { eventGuestIds: eventGuestIds } });
    }

    getByEventInvitationIds = (eventInvitationIds: string[]): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`eventguestinvitation/getbyeventinvitationids`, { params: { eventInvitationIds: eventInvitationIds } });
    }

    add = (eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPost(`eventguestinvitation/`, eventGuestInvitation);
    }

    update = (id: string, eventGuestInvitation: EventGuestInvitation): Observable<EventGuestInvitation> => {
        return this.httpPut(`eventguestinvitation/${id}`, eventGuestInvitation);
    }

    delete = (id: string): Observable<EventGuestInvitation> => {
        return this.httpDelete(`eventguestinvitation/${id}`);
    }

    rsvp = (code: string): Observable<EventGuestInvitation> => {
        return this.httpGet(`eventguestinvitation/${code}/rsvp`);
    }
}