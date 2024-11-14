import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { GuestInvitation, Invitation } from '@shared/models';
import { Content } from '@shared/models/content.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventInvitationService extends BaseApiService {
    getAll = (): Observable<Invitation[]> => {
        return this.httpGet(`invitation`);
    }

    get = (id: string): Observable<Invitation> => {
        return this.httpGet(`invitation/${id}`);
    }

    getGuests = (id: string): Observable<GuestInvitation[]> => {
        return this.httpGet(`invitation/${id}/guests`);
    }

    add = (invitation: Invitation, content: Content): Observable<Invitation> => {
        return this.httpPost(`invitation`, { ...invitation, html: content.htmlContent });
    }

    update = (invitation: Invitation, content: Content): Observable<Invitation> => {
        return this.httpPut(`invitation/${invitation.id}`, { ...invitation, html: content.htmlContent });
    }

    delete = (id: string): Observable<Invitation[]> => {
        return this.httpDelete(`invitation/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Invitation[]> => {
        return this.httpDeleteSelected(`invitation`, ids);
    }
}