import { lastValueFrom } from 'rxjs';
import { EventGuest } from '../models/event-guest';

import { BaseService } from './base.service';

export class EventGuestService extends BaseService {
    get = async (id: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventguest/${id}`, { headers: this.headers }));
    }

    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventguest`, { headers: this.headers }));
    }

    add = async (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/eventguest`, {
            eventId: eventGuest.eventId,
            guest: eventGuest.guest,
            guestId: eventGuest.guestId,
            maxGuests: eventGuest.maxGuests,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        }, { headers: this.headers }));
    }

    update = async (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]) => {
        return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/eventguest/${eventGuest.id}`, {
            eventId: eventGuest.eventId,
            guest: eventGuest.guest,
            guestId: eventGuest.guestId,
            maxGuests: eventGuest.maxGuests,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        }, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/eventguest/${id}`, { headers: this.headers }));
    }
}