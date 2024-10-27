import { Injectable } from '@angular/core';
import { Guest } from '../models/guest';
import { lastValueFrom, Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';
import { EventGuestInvitationRsvp } from '../models/event-guest-invitation-rsvp';
import { EventGuestInvitation } from '../models/event-guest-invitation';

@Injectable({
  providedIn: 'root'
})
export class GuestService extends BaseApiService {
  get = (id: string): Observable<{ guest: Guest, guestInvitations: EventGuestInvitation[] }> => {
    return this.httpGet<{ guest: Guest, guestInvitations: EventGuestInvitation[] }>(`api/guest/${id}`);
  }

  getAll = (): Observable<Guest[]> => {
    return this.httpGet<Guest[]>(`api/guest/`);
  }

  add = (guest: Guest, eventRoleIds: string[], invitationIds: string[]): Observable<Guest> => {
    return this.httpPost<Guest>(`api/guest`, {
      eventId: guest.eventId,
      ...guest,
      eventRoleIds: eventRoleIds,
      invitationIds: invitationIds
    });
  }

  rsvp = (id: string, eventInvitationId: string, rsvp: EventGuestInvitationRsvp): Observable<EventGuestInvitationRsvp> => {
    return this.httpPost(`api/guest/${id}/rsvp/${eventInvitationId}`, rsvp);
  }

  update = (guest: Guest, eventRoleIds: string[], invitationIds: string[]): Observable<Guest> => {
    return this.httpPut(`api/guest/${guest.id}`, {
      eventId: guest.eventId,
      ...guest,
      eventRoleIds: eventRoleIds,
      invitationIds: invitationIds
    });
  }

  delete = async (id: string) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/guest/${id}`, { headers: this.headers }));
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/guest`, { headers: this.headers, body: ids }));
  }
}