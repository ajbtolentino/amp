import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventGuest, EventGuestInvitation } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventGuestService extends BaseApiService {
    get = (id: string): Observable<EventGuest> => {
        return this.httpGet(`eventguest/${id}`);
    }

    getAll = (): Observable<EventGuest[]> => {
        return this.httpGet<EventGuest[]>(`eventguest`);
    }

    getInvitations = (eventGuestId: string): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`eventguest/${eventGuestId}/invitations`);
    }

    add = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPost(`eventguest`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    update = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPut(`eventguest/${eventGuest.id}`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    delete = (id: string): Observable<EventGuest> => {
        return this.httpDelete<EventGuest>(`eventguest/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<EventGuest[]> => {
        return this.httpDeleteSelected(`eventguest`, ids);
    }
}