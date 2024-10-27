import { lastValueFrom, Observable } from 'rxjs';
import { EventInvitation } from '../models/event-invitation';
import { BaseApiService } from './base.api.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class EventInvitationService extends BaseApiService {
    getAll = async () => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventinvitation`, { headers: this.headers }));
    }

    get = async (id: string | undefined | null = null) => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventinvitation/${id}`, { headers: this.headers }));
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