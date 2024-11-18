import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Zone } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ZoneService extends BaseApiService {
    get = (id: string): Observable<Zone> => {
        return this.httpGet(`zone/${id}`);
    }

    getAll = (): Observable<Zone[]> => {
        return this.httpGet<Zone[]>(`zone`);
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<Zone[]>(`zone/getbyids`, { params: { ids: ids } });
    }

    add = (zone: Zone): Observable<Zone> => {
        return this.httpPost(`zone`, zone);
    }

    update = (zone: Zone): Observable<Zone> => {
        return this.httpPut(`zone/${zone.id}`, zone);
    }

    delete = (id: string): Observable<Zone> => {
        return this.httpDelete<Zone>(`zone/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Zone[]> => {
        return this.httpDeleteSelected(`zone`, ids);
    }
}