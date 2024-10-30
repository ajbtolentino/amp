import { lastValueFrom, Observable } from 'rxjs';
import { EventGuest } from '../models/event-guest';
import { BaseApiService } from './base.api.service';
import { Guest } from '../models/guest';
import { EventInvitationInfo } from '../models/event-invitation-info';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class EventGuestService extends BaseApiService {
    get = (id: string): Observable<{ eventGuest: EventGuest, guest: Guest }> => {
        return this.httpGet(`api/eventguest/${id}`);
    }

    getAll = async () => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguest`, { headers: this.headers }));
    }

    getInvitations = (eventGuestId: string): Observable<EventInvitationInfo[]> => {
        return this.httpGet(`api/eventguest/${eventGuestId}/invitations`);
    }

    add = (eventGuest: EventGuest, guest: Guest): Observable<EventGuest> => {
        return this.httpPost(`api/eventguest`, {
            guest: guest,
            eventGuest: eventGuest
        });
    }

    update = (eventGuest: EventGuest, guest: Guest): Observable<EventGuest> => {
        return this.httpPut(`api/eventguest/${eventGuest.id}`, {
            guest: guest,
            eventGuest: eventGuest
        });
    }

    delete = (id: string): Observable<EventGuest> => {
        return this.httpDelete<EventGuest>(`api/eventguest/${id}`);
    }
}