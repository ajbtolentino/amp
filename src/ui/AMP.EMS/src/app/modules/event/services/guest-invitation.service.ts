import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Guest, GuestInvitation, Invitation } from '@shared/models';
import { Observable } from 'rxjs';

export interface EventGuestInvitationResponse {
    guest: Guest;
    eventGuestInvitation: GuestInvitation;
    eventInvitation: Invitation;
}

@Injectable({
    providedIn: 'root'
})
export class GuestInvitationService extends BaseApiService {
    getByGuestIds = (guestIds: string[]): Observable<GuestInvitation[]> => {
        return this.httpGet(`guestinvitation/getbyguestids`, { params: { guestIds: guestIds } });
    }

    getByInvitationIds = (invitationIds: string[]): Observable<GuestInvitation[]> => {
        return this.httpGet(`guestinvitation/getbyinvitationids`, { params: { invitationIds: invitationIds } });
    }

    add = (eventGuestInvitation: GuestInvitation): Observable<GuestInvitation> => {
        return this.httpPost(`guestinvitation/`, eventGuestInvitation);
    }

    update = (id: string, eventGuestInvitation: GuestInvitation): Observable<GuestInvitation> => {
        return this.httpPut(`guestinvitation/${id}`, eventGuestInvitation);
    }

    delete = (id: string): Observable<GuestInvitation> => {
        return this.httpDelete(`guestinvitation/${id}`);
    }

    rsvp = (code: string): Observable<GuestInvitation> => {
        return this.httpGet(`guestinvitation/${code}/rsvp`);
    }
}