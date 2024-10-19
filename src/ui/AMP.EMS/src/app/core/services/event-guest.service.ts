import { lastValueFrom } from 'rxjs';
import { EventGuest } from '../models/event-guest';

import { BaseService } from './base.service';

export class GuestService extends BaseService {
    details = async (eventId: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventguest/${eventId}/details`, { headers: this.headers }));
    }

    get = async (id: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventguest/${id}`, { headers: this.headers }));
    }

    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventguest`, { headers: this.headers }));
    }

    add = async (eventGuest: EventGuest) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/eventguest`, eventGuest, { headers: this.headers }));
    }

    update = async (invitation: EventGuest) => {
        return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/eventguest/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/eventguest/${id}`, { headers: this.headers }));
    }
}