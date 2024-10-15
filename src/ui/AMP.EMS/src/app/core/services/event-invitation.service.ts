import { lastValueFrom } from 'rxjs';
import { Invitation } from '../models/invitation';
import { BaseService } from './base.service';

export class InvitationService extends BaseService {
    getAll = async (eventId: string | undefined | null = null) => {
        if (eventId) return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventinvitation/${eventId}/details`, { headers: this.headers }));

        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventinvitation`, { headers: this.headers }));
    }

    add = async (invitation: Invitation) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/eventinvitation`, invitation, { headers: this.headers }));
    }

    update = async (invitation: Invitation) => {
        return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/eventinvitation/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/eventinvitation/${id}`, { headers: this.headers }));
    }

    rsvp = async (code: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventinvitation/${code}/rsvp`, { headers: this.headers }));
    }
}