import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventVendor, Vendor } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventVendorService extends BaseApiService {
    get = (id: string): Observable<EventVendor> => {
        return this.httpGet<EventVendor>(`eventvendor/${id}`);
    }

    getAll = (): Observable<EventVendor[]> => {
        return this.httpGet<EventVendor[]>(`eventvendor/`);
    }

    add = (vendor: Vendor): Observable<EventVendor> => {
        return this.httpPost<EventVendor>(`eventvendor`, vendor);
    }

    update = (eventVendor: EventVendor): Observable<EventVendor> => {
        return this.httpPut<EventVendor>(`eventvendor`, eventVendor);
    }

    delete = (id: string): Observable<EventVendor> => {
        return this.httpDelete(`eventvendor/${id}`);
    }
}
