import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventVendorTypeBudget } from '@shared/models/event-vendor-type-budget.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventVendorTypeBudgetService extends BaseApiService {
    get = (id: string): Observable<EventVendorTypeBudget> => {
        return this.httpGet<EventVendorTypeBudget>(`eventVendorTypeBudget/${id}`);
    }

    getByIds = (ids: string[]): Observable<EventVendorTypeBudget[]> => {
        return this.httpGet<EventVendorTypeBudget[]>(`eventVendorTypeBudget/getbyids`, { params: { ids: ids } });
    }

    getAll = (): Observable<EventVendorTypeBudget[]> => {
        return this.httpGet<EventVendorTypeBudget[]>(`eventVendorTypeBudget/`);
    }

    add = (eventVendorTypeBudget: EventVendorTypeBudget): Observable<EventVendorTypeBudget> => {
        return this.httpPost<EventVendorTypeBudget>(`eventVendorTypeBudget/`, eventVendorTypeBudget);
    }

    update = (eventVendorTypeBudget: EventVendorTypeBudget): Observable<EventVendorTypeBudget> => {
        return this.httpPut<EventVendorTypeBudget>(`eventVendorTypeBudget/${eventVendorTypeBudget.id}`, eventVendorTypeBudget);
    }

    delete = (id: string): Observable<EventVendorTypeBudget> => {
        return this.httpDelete(`eventVendorTypeBudget/${id}`);
    }
}
