import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { EventGuestRole } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventGuestRoleService extends BaseApiService {
    get = (id: string): Observable<EventGuestRole> => {
        return this.httpGet(`guest/${id}`);
    }

    getAll = (): Observable<EventGuestRole[]> => {
        return this.httpGet<EventGuestRole[]>(`eventGuestRole`);
    }

    getByEventGuestIds = (eventGuestIds: string[]) => {
        return this.httpGet<EventGuestRole[]>(`eventGuestRole/getbyeventguestids`, { params: { eventGuestIds: eventGuestIds } });
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<EventGuestRole[]>(`eventGuestRole/getbyids`, { params: { ids: ids } });
    }

    add = (eventGuestRole: EventGuestRole): Observable<EventGuestRole> => {
        return this.httpPost(`eventGuestRole/`, eventGuestRole);
    }

    update = (eventGuestRole: EventGuestRole): Observable<EventGuestRole> => {
        return this.httpPut(`eventguestinvitation/${eventGuestRole.id}`, eventGuestRole);
    }

    delete = (id: string): Observable<EventGuestRole> => {
        return this.httpDelete(`eventguestinvitation/${id}`);
    }
}