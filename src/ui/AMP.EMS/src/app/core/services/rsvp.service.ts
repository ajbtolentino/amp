import { Injectable } from '@angular/core';
import { GuestInvitationRsvp, GuestInvitationRsvpItem } from '@shared/models';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class RsvpService extends BaseApiService {
    getItemsByIds = (ids: string[]): Observable<GuestInvitationRsvpItem[]> => {
        return this.httpGet(`rsvp/getitemsbyids`, { params: { ids: ids } });
    }

    getByGuestInvitationIds = (guestInvitationIds: string[]): Observable<GuestInvitationRsvp[]> => {
        return this.httpGet(`rsvp/getbyguestinvitationids`, { params: { guestInvitationIds: guestInvitationIds } });
    }

    update = (id: string, data: string): Observable<GuestInvitationRsvp> => {
        console.log(data);
        return this.httpPut(`rsvp/${id}`, { data: data });
    }
}