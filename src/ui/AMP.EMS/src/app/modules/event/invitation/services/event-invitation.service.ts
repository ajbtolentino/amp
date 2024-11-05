import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventGuestInvitation, EventInvitation } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventInvitationService extends BaseApiService {
    getAll = (): Observable<EventInvitation[]> => {
        return this.httpGet(`api/eventinvitation`);
    }

    get = (id: string): Observable<EventInvitation> => {
        return this.httpGet(`api/eventinvitation/${id}`);
    }

    getGuests = (id: string): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`api/eventinvitation/${id}/guests`);
    }

    add = (invitation: EventInvitation): Observable<EventInvitation> => {
        return this.httpPost(`api/eventinvitation`, invitation);
    }

    update = (invitation: EventInvitation): Observable<EventInvitation> => {
        return this.httpPut(`api/eventinvitation/${invitation.id}`, invitation);
    }

    delete = (id: string): Observable<EventInvitation[]> => {
        return this.httpDelete(`api/eventinvitation/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<EventInvitation[]> => {
        return this.httpDeleteSelected(`api/eventinvitation`, ids);
    }
}