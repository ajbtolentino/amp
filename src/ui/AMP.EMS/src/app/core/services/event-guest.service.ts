import { lastValueFrom, Observable } from 'rxjs';
import { EventGuest } from '../models/event-guest';

import { BaseService } from './base.service';

export class EventGuestService extends BaseService {
    get = (id: string): Observable<EventGuest> => {
        return this.httpGet(`api/eventguest/${id}`);
    }

    getAll = async () => {
        return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguest`, { headers: this.headers }));
    }

    add = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPost(`api/eventguest`, {
            eventId: eventGuest.eventId,
            guest: eventGuest.guest,
            guestId: eventGuest.guestId,
            maxGuests: eventGuest.maxGuests,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    update = (eventGuest: EventGuest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<EventGuest> => {
        return this.httpPut(`api/eventguest/${eventGuest.id}`, {
            ...eventGuest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    delete = (id: string) : Observable<EventGuest> => {
        return this.httpDelete<EventGuest>(`api/eventguest/${id}`);
    }
}