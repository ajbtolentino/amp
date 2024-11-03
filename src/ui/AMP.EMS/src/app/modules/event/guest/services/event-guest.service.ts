import { lastValueFrom, Observable } from 'rxjs';
import { BaseApiService } from '@core/services/base.api.service';
import { Injectable } from '@angular/core';
import { EventGuest, EventGuestInvitation } from '@shared/models';

@Injectable({
    providedIn: 'root'
})
export class EventGuestService extends BaseApiService {
    get = (id: string): Observable<EventGuest> => {
        return this.httpGet(`api/eventguest/${id}`);
    }

    getAll = async () => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguest`, { headers: this.headers }));
    }

    getInvitations = (eventGuestId: string): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`api/eventguest/${eventGuestId}/invitations`);
    }

    add = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPost(`api/eventguest`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    update = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPut(`api/eventguest/${eventGuest.id}`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    delete = (id: string): Observable<EventGuest> => {
        return this.httpDelete<EventGuest>(`api/eventguest/${id}`);
    }
}