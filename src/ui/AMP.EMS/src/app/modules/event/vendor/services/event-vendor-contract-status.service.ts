import { Injectable } from '@angular/core';
import { Lookup } from '@shared/models/lookup-model';
import { Observable } from 'rxjs';
import { BaseApiService } from '../../../../core/services/base.api.service';

@Injectable({
    providedIn: 'root'
})
export class EventVendorContractStateService extends BaseApiService {
    get = (id: string): Observable<Lookup> => {
        return this.httpGet<Lookup>(`api/eventvendorcontract/${id}`);
    }

    getAll = (): Observable<Lookup[]> => {
        return this.httpGet<Lookup[]>(`api/eventvendorcontract/`);
    }

    add = (eventVendorContractStatus: Lookup): Observable<Lookup> => {
        return this.httpPost<Lookup>(`api/eventvendorcontract`, eventVendorContractStatus);
    }

    update = (eventVendorContractStatus: Lookup): Observable<Lookup> => {
        return this.httpPut<Lookup>(`api/eventvendorcontract`, eventVendorContractStatus);
    }

    delete = (id: string): Observable<Lookup> => {
        return this.httpDelete(`api/eventvendorcontract/${id}`);
    }
}
