import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Guest } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class GuestService extends BaseApiService {
    get = (id: string): Observable<Guest> => {
        return this.httpGet(`api/guest/${id}`);
    }

    getAll = (): Observable<Guest[]> => {
        return this.httpGet<Guest[]>(`api/guest`);
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<Guest[]>(`api/guest/getbyids`, { params: { ids: ids } });
    }

    add = (guest: Guest): Observable<Guest> => {
        return this.httpPost(`api/guest`, guest);
    }

    update = (guest: Guest): Observable<Guest> => {
        return this.httpPut(`api/guest/${guest.id}`,);
    }

    delete = (id: string): Observable<Guest> => {
        return this.httpDelete<Guest>(`api/guest/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Guest[]> => {
        return this.httpDeleteSelected(`api/guest`, ids);
    }
}