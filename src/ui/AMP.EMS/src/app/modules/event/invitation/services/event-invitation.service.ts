import { lastValueFrom, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventInvitation, EventGuestInvitation } from '@shared/models';

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