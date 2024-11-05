import { Injectable } from '@angular/core';

import { lastValueFrom, Observable } from 'rxjs';

import { Event, EventGuest, EventGuestRole, EventInvitation } from '@shared/models';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class EventService extends BaseApiService {
    get = (id: string): Observable<Event> => {
        return this.httpGet(`api/event/${id}`);
    }

    getRoles = (id: string): Observable<EventGuestRole[]> => {
        return this.httpGet<EventGuestRole[]>(`api/event/${id}/roles`);
    }

    getInvitations = (id: string): Observable<EventInvitation[]> => {
        return this.httpGet<EventInvitation[]>(`api/event/${id}/invitations`);
    }

    getGuests = (id: string): Observable<EventGuest[]> => {
        return this.httpGet<EventGuest[]>(`api/event/${id}/guests`);
    }

    getAll = (): Observable<Event[]> => {
        return this.httpGet<Event[]>(`api/event/`);
    }

    add = (event: Event): Observable<Event> => {
        return this.httpPut(`api/event`, event);
    }

    update = (event: Event): Observable<Event> => {
        return this.httpPut(`api/event/${event.id}`, event);
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
    }

    deleteSelected = async (ids: string[]) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event`, { headers: this.headers, body: ids }));
    }
}
