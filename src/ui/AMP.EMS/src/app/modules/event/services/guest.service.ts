import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Guest } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class GuestService extends BaseApiService {
    get = (id: string): Observable<Guest> => {
        return this.httpGet(`guest/${id}`);
    }

    getAll = (): Observable<Guest[]> => {
        return this.httpGet<Guest[]>(`guest`);
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<Guest[]>(`guest/getbyids`, { params: { ids: ids } });
    }

    add = (guest: Guest, roleIds: string[], invitationIds: string[]): Observable<Guest> => {
        return this.httpPost(`guest`, {
            ...guest,
            roleIds: roleIds,
            invitationIds: invitationIds
        });
    }

    update = (guest: Guest, eventRoleIds: string[], eventInvitationIds: string[]): Observable<Guest> => {
        return this.httpPut(`guest/${guest.id}`, {
            ...guest,
            eventRoleIds: eventRoleIds,
            eventInvitationIds: eventInvitationIds
        });
    }

    delete = (id: string): Observable<Guest> => {
        return this.httpDelete<Guest>(`guest/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Guest[]> => {
        return this.httpDeleteSelected(`guest`, ids);
    }
}