import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Event } from '../models/event';
import { lastValueFrom, map, Observable } from 'rxjs';

import { BaseApiService } from './base.api.service';
import { EventInvitation } from '../models/event-invitation';
import { EventGuestRole } from '../models/event-guest-role';
import { Guest } from '../models/guest';
import { EventInvitationInfo } from '../models/event-invitation-info';

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

    getInvitations = (id: string): Observable<EventInvitationInfo[]> => {
        return this.httpGet<EventInvitationInfo[]>(`api/event/${id}/invitations`);
    }

    getGuests = (id: string): Observable<Guest[]> => {
        return this.httpGet<Guest[]>(`api/event/${id}/guests`);
    }

    getAll = (): Observable<Event[]> => {
        return this.httpGet<Event[]>(`api/event/`);
    }

    add = async (event: Event) => {
        return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/event`, event, { headers: this.headers }));
    }

    addRole = (id: string, eventRole: EventGuestRole): Observable<Event> => {
        return this.httpPost<EventGuestRole>(`api/event/${id}`, eventRole);
    }

    update = async (event: Event) => {
        return await lastValueFrom(this.httpClient.put<any>(`${this.API_URL}/api/event/${event.id}`, event, { headers: this.headers }));
    }

    updateRole = (id: string, eventRole: EventGuestRole): Observable<Event> => {
        return this.httpPut<EventGuestRole>(`api/event/${id}`, eventRole);
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
    }

    deleteRole = (id: string, eventRoleId: string): Observable<Event> => {
        return this.httpDelete<Event>(`api/event/${id}/eventRole/${eventRoleId}`);
    }

    deleteSelected = async (ids: string[]) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/event`, { headers: this.headers, body: ids }));
    }
}