import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventVendorContract } from '@shared/models/event-vendor-contract.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventVendorContractService extends BaseApiService {
    get = (id: string): Observable<EventVendorContract> => {
        return this.httpGet<EventVendorContract>(`api/eventvendorcontract/${id}`);
    }

    getAll = (): Observable<EventVendorContract[]> => {
        return this.httpGet<EventVendorContract[]>(`api/eventvendorcontract/`);
    }

    add = (eventVendorContract: EventVendorContract): Observable<EventVendorContract> => {
        return this.httpPost<EventVendorContract>(`api/eventvendorcontract`, eventVendorContract);
    }

    update = (eventVendorContract: EventVendorContract): Observable<EventVendorContract> => {
        return this.httpPut<EventVendorContract>(`api/eventvendorcontract`, eventVendorContract);
    }

    delete = (id: string): Observable<EventVendorContract> => {
        return this.httpDelete(`api/eventvendorcontract/${id}`);
    }
}
