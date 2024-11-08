import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventVendor } from '@shared/models';
import { Vendor } from '@shared/models/vendor-model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventVendorService extends BaseApiService {
    get = (id: string): Observable<EventVendor> => {
        return this.httpGet<EventVendor>(`api/eventvendor/${id}`);
    }

    getAll = (): Observable<EventVendor[]> => {
        return this.httpGet<EventVendor[]>(`api/eventvendor/`);
    }

    add = (vendor: Vendor): Observable<EventVendor> => {
        return this.httpPost<EventVendor>(`api/eventvendor`, vendor);
    }

    update = (eventVendor: EventVendor): Observable<EventVendor> => {
        return this.httpPut<EventVendor>(`api/eventvendor`, eventVendor);
    }

    delete = (id: string): Observable<EventVendor> => {
        return this.httpDelete(`api/eventvendor/${id}`);
    }
}
