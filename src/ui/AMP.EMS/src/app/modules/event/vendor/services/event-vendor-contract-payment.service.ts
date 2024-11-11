import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventVendorContractPayment, Transaction } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventVendorContractPaymentService extends BaseApiService {
    get = (id: string): Observable<EventVendorContractPayment> => {
        return this.httpGet<EventVendorContractPayment>(`eventVendorContractPayment/${id}`);
    }

    getAll = (): Observable<EventVendorContractPayment[]> => {
        return this.httpGet<EventVendorContractPayment[]>(`eventVendorContractPayment/`);
    }

    add = (eventVendorContractPayment: EventVendorContractPayment): Observable<EventVendorContractPayment> => {
        return this.httpPost<EventVendorContractPayment>(`eventVendorContractPayment`, eventVendorContractPayment);
    }

    addTransaction = (id: string, transaction: Transaction): Observable<EventVendorContractPayment> => {
        return this.httpPost<EventVendorContractPayment>(`eventVendorContractPayment/${id}/transaction`, transaction);
    }

    update = (eventVendorContractPayment: EventVendorContractPayment): Observable<EventVendorContractPayment> => {
        return this.httpPut<EventVendorContractPayment>(`eventVendorContractPayment/${eventVendorContractPayment.id}`, eventVendorContractPayment);
    }

    delete = (id: string): Observable<EventVendorContractPayment> => {
        return this.httpDelete(`eventVendorContractPayment/${id}`);
    }
}
