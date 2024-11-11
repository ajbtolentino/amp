import { Injectable } from '@angular/core';

import { lastValueFrom, Observable } from 'rxjs';

import { Event, EventGuest, EventGuestRole, EventInvitation, EventVendorContract } from '@shared/models';
import { Lookup } from '@shared/models/lookup.model';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class EventService extends BaseApiService {
    get = (id: string): Observable<Event> => {
        return this.httpGet(`event/${id}`);
    }

    getRoles = (id: string): Observable<EventGuestRole[]> => {
        return this.httpGet<EventGuestRole[]>(`event/${id}/roles`);
    }

    getInvitations = (id: string): Observable<EventInvitation[]> => {
        return this.httpGet<EventInvitation[]>(`event/${id}/invitations`);
    }

    getGuests = (id: string): Observable<EventGuest[]> => {
        return this.httpGet<EventGuest[]>(`event/${id}/guests`);
    }

    getVendorContracts = (id: string): Observable<EventVendorContract[]> => {
        return this.httpGet<EventVendorContract[]>(`event/${id}/vendorcontracts`);
    }

    getVendorContractStates = (id: string): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/vendorcontractstates`);
    }

    getVendorContractPaymentTypes = (id: string): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/vendorcontractpaymenttypes`);
    }

    getVendorContractPaymentStates = (id: string): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/vendorcontractpaymentstates`);
    }

    getVendorTypeBudgets = (id: string): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/vendortypebudgets`);
    }

    getAll = (): Observable<Event[]> => {
        return this.httpGet<Event[]>(`event/`);
    }

    add = (event: Event): Observable<Event> => {
        return this.httpPost(`event`, event);
    }

    update = (event: Event): Observable<Event> => {
        return this.httpPut(`event/${event.id}`, event);
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/event/${id}`, { headers: this.headers }));
    }

    deleteSelected = async (ids: string[]) => {
        return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/event`, { headers: this.headers, body: ids }));
    }
}
