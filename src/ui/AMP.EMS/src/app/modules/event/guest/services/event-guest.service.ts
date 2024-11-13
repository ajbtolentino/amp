import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Guest, GuestInvitation } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventGuestService extends BaseApiService {
    get = (id: string): Observable<Guest> => {
        return this.httpGet(`eventguest/${id}`);
    }

    getAll = (): Observable<Guest[]> => {
        return this.httpGet<Guest[]>(`eventguest`);
    }

    getInvitations = (eventGuestId: string): Observable<GuestInvitation[]> => {
        return this.httpGet(`eventguest/${eventGuestId}/invitations`);
    }

    add = (eventGuest: Guest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<Guest> => {
        return this.httpPost(`eventguest`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    update = (eventGuest: Guest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<Guest> => {
        return this.httpPut(`eventguest/${eventGuest.id}`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    delete = (id: string): Observable<Guest> => {
        return this.httpDelete<Guest>(`eventguest/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Guest[]> => {
        return this.httpDeleteSelected(`eventguest`, ids);
    }
}