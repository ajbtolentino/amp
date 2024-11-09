import { Injectable } from '@angular/core';
import { Lookup } from '@shared/models/lookup.model';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class LookupService extends BaseApiService {
    get = (lookupType: string, id: string): Observable<Lookup> => {
        return this.httpGet(`api/${lookupType}/${id}`);
    }

    getAll = (lookupType: string): Observable<Lookup[]> => {
        return this.httpGet(`api/${lookupType}`);
    }

    getByIds = (lookupType: string, ids: string[]): Observable<Lookup[]> => {
        return this.httpGet(`api/${lookupType}`, { params: { ids: ids } });
    }

    add = (lookupType: string, eventRole: Lookup): Observable<Lookup> => {
        return this.httpPost(`api/${lookupType}`, eventRole);
    }

    update = (lookupType: string, eventRole: Lookup): Observable<Lookup> => {
        return this.httpPut(`api/${lookupType}/${eventRole.id}`, eventRole);
    }

    delete = (lookupType: string, id: string): Observable<Lookup> => {
        return this.httpDelete(`api/${lookupType}/${id}`);
    }

    deleteSelected = (lookupType: string, ids: string[]): Observable<Lookup> => {
        return this.httpDeleteSelected(`api/${lookupType}`, ids);
    }
}
