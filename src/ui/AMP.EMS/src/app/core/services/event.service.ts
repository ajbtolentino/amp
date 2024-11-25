import { Injectable } from '@angular/core';

import { lastValueFrom, Observable } from 'rxjs';

import { Account, Event, EventAccount, Guest, GuestRole, Invitation, PagedResult, Timeline, Transaction, VendorContract, VendorContractPayment, Zone } from '@shared/models';
import { Lookup } from '@shared/models/lookup.model';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class EventService extends BaseApiService {
    get = (id: string): Observable<Event> => {
        return this.httpGet(`event/${id}`);
    }

    getEventAccounts = (id: string): Observable<EventAccount[]> => {
        return this.httpGet<Account[]>(`event/${id}/accounts`);
    }

    getRoles = (id: string): Observable<GuestRole[]> => {
        return this.httpGet<GuestRole[]>(`event/${id}/roles`);
    }

    getInvitations = (id: string): Observable<Invitation[]> => {
        return this.httpGet<Invitation[]>(`event/${id}/invitations`);
    }

    getGuests = (id: string, pageNumber: number, pageSize: number, search?: string, sortField?: string, sortDirection?: 'Ascending' | 'Descending', roleIds?: string[]): Observable<PagedResult<Guest>> => {
        return this.httpGet<PagedResult<Guest>>(`event/${id}/guests`, {
            params: {
                pageNumber: pageNumber + 1,
                pageSize: pageSize,
                search: search || '',
                sortField: sortField || '',
                sortDirection: sortDirection || '',
                roleIds: roleIds
            }
        });
    }

    unseatedGuests = (id: string): Observable<Guest[]> => {
        return this.httpGet<Guest[]>(`event/${id}/unseatedAttendees`);
    }

    getVendorContracts = (id: string): Observable<VendorContract[]> => {
        return this.httpGet<VendorContract[]>(`event/${id}/vendorcontracts`);
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

    getTimelines = (id: string): Observable<Timeline[]> => {
        return this.httpGet<Account[]>(`event/${id}/timelines`);
    }

    getTransactions = (id: string): Observable<Transaction[]> => {
        return this.httpGet<Account[]>(`event/${id}/transactions`);
    }

    getUnreconciledPayments = (id: string): Observable<VendorContractPayment[]> => {
        return this.httpGet<VendorContractPayment[]>(`event/${id}/unreconciledpayments`);
    }

    getVendorTypeBudgets = (id: string): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/vendortypebudgets`);
    }

    getZones = (id: string): Observable<Zone[]> => {
        return this.httpGet<Lookup[]>(`event/${id}/zones`);
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
