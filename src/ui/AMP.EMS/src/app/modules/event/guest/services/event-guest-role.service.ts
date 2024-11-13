import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { GuestRole } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventGuestRoleService extends BaseApiService {
    get = (id: string): Observable<GuestRole> => {
        return this.httpGet(`guest/${id}`);
    }

    getAll = (): Observable<GuestRole[]> => {
        return this.httpGet<GuestRole[]>(`guestRole`);
    }

    getByEventGuestIds = (guestids: string[]) => {
        return this.httpGet<GuestRole[]>(`guestrole/getbyguestids`, { params: { guestIds: guestids } });
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<GuestRole[]>(`guestrole/getbyids`, { params: { ids: ids } });
    }

    add = (eventGuestRole: GuestRole): Observable<GuestRole> => {
        return this.httpPost(`guestrole/`, eventGuestRole);
    }

    update = (eventGuestRole: GuestRole): Observable<GuestRole> => {
        return this.httpPut(`guestinvitation/${eventGuestRole.id}`, eventGuestRole);
    }

    delete = (id: string): Observable<GuestRole> => {
        return this.httpDelete(`guestinvitation/${id}`);
    }
}