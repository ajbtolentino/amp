import { lastValueFrom } from 'rxjs';
import { EventInvitation } from '../models/event-invitation';
import { BaseService } from './base.service';

export class EventGuestInvitationService extends BaseService {
    getAll = async (eventId: string | undefined | null = null) => {
        if (eventId) return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguestinvitation/${eventId}/details`, { headers: this.headers }));

        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguestinvitation`, { headers: this.headers }));
    }

    get = async (eventInvitationId: string | undefined | null = null) => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguestinvitation/${eventInvitationId}`, { headers: this.headers }));
    }

    add = async (invitation: EventInvitation) => {
        return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/eventguestinvitation`, invitation, { headers: this.headers }));
    }

    update = async (invitation: EventInvitation) => {
        return await lastValueFrom(this.httpClient.put<any>(`${this.API_URL}/api/eventguestinvitation/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/eventguestinvitation/${id}`, { headers: this.headers }));
    }

    rsvp = async (code: string) => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguestinvitation/${code}/rsvp`, { headers: this.headers }));
    }
}