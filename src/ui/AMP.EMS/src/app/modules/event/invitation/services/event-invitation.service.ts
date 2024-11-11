import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventGuestInvitation, EventInvitation } from '@shared/models';
import { Content } from '@shared/models/content.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventInvitationService extends BaseApiService {
    getAll = (): Observable<EventInvitation[]> => {
        return this.httpGet(`eventinvitation`);
    }

    get = (id: string): Observable<EventInvitation> => {
        return this.httpGet(`eventinvitation/${id}`);
    }

    getGuests = (id: string): Observable<EventGuestInvitation[]> => {
        return this.httpGet(`eventinvitation/${id}/guests`);
    }

    add = (invitation: EventInvitation, content: Content): Observable<EventInvitation> => {
        return this.httpPost(`eventinvitation`, { ...invitation, html: content.htmlContent });
    }

    update = (invitation: EventInvitation, content: Content): Observable<EventInvitation> => {
        return this.httpPut(`eventinvitation/${invitation.id}`, { ...invitation, html: content.htmlContent });
    }

    delete = (id: string): Observable<EventInvitation[]> => {
        return this.httpDelete(`eventinvitation/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<EventInvitation[]> => {
        return this.httpDeleteSelected(`eventinvitation`, ids);
    }
}