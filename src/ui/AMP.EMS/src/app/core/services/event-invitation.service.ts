import { lastValueFrom, Observable } from 'rxjs';
import { EventInvitation } from '../models/event-invitation';
import { BaseApiService } from './base.api.service';
import { Injectable } from '@angular/core';
import { Guest } from '../models/guest';
import { EventGuestInvitation } from '../models/event-guest-invitation';

@Injectable({
    providedIn: 'root'
})
export class EventInvitationService extends BaseApiService {
    getAll = async () => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventinvitation`, { headers: this.headers }));
    }

    get = (id: string): Observable<EventInvitation> => {
        return this.httpGet(`api/eventinvitation/${id}`);
    }

    getGuests = (id: string): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`api/eventinvitation/${id}/guests`);
    }

    add = async (invitation: EventInvitation) => {
        return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/eventinvitation`, invitation, { headers: this.headers }));
    }

    update = async (invitation: EventInvitation) => {
        return await lastValueFrom(this.httpClient.put<any>(`${this.API_URL}/api/eventinvitation/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/eventinvitation/${id}`, { headers: this.headers }));
    }
}