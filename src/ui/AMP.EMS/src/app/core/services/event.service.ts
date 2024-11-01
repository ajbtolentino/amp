import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Event } from '../models/event';
import { lastValueFrom, map, Observable } from 'rxjs';

import { BaseApiService } from './base.api.service';
import { EventInvitation } from '../models/event-invitation';
import { EventGuestRole } from '../models/event-guest-role';
import { Guest } from '../models/guest';
import { EventInvitationInfo } from '../models/event-invitation-info';
import { EventGuest } from '../models/event-guest';

@Injectable({
    providedIn: 'root'
})
export class EventService extends BaseApiService {
    get = async (id: string) => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
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

    add = async (event: Event) => {
        return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/event`, event, { headers: this.headers }));
    }

    update = async (event: Event) => {
        return await lastValueFrom(this.httpClient.put<any>(`${this.API_URL}/api/event/${event.id}`, event, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
    }

    deleteSelected = async (ids: string[]) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event`, { headers: this.headers, body: ids }));
    }
}
