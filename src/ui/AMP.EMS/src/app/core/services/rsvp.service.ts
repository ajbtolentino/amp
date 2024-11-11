import { Injectable } from '@angular/core';
import { EventGuestInvitationRsvp } from '@shared/models';
import { EventGuestInvitationRsvpItem } from '@shared/models/event-guest-invitation-rsvp-item.model';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class RsvpService extends BaseApiService {
    getItemsByIds = (ids: string[]): Observable<EventGuestInvitationRsvpItem[]> => {
        return this.httpGet(`rsvp/getitemsbyids`, { params: { ids: ids } });
    }

    getByEventGuestInvitationIds = (eventGuestInvitationIds: string[]): Observable<EventGuestInvitationRsvp[]> => {
        return this.httpGet(`rsvp/getbyeventguestinvitationids`, { params: { eventGuestInvitationIds: eventGuestInvitationIds } });
    }

    add = (rsvp: EventGuestInvitationRsvp): Observable<EventGuestInvitationRsvp> => {
        return this.httpPost(`rsvp`, rsvp);
    }
}