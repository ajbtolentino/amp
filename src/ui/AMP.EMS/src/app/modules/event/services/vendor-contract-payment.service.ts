import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { Transaction, VendorContractPayment } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class VendorContractPaymentService extends BaseApiService {
    get = (id: string): Observable<VendorContractPayment> => {
        return this.httpGet<VendorContractPayment>(`vendorContractPayment/${id}`);
    }

    getTransaction = (id: string): Observable<Transaction> => {
        return this.httpGet<Transaction>(`vendorContractPayment/${id}/transaction`);
    }

    getAll = (): Observable<VendorContractPayment[]> => {
        return this.httpGet<VendorContractPayment[]>(`vendorContractPayment/`);
    }

    add = (vendorContractPayment: VendorContractPayment): Observable<VendorContractPayment> => {
        return this.httpPost<VendorContractPayment>(`vendorContractPayment`, vendorContractPayment);
    }

    addTransaction = (id: string, transaction: Transaction): Observable<VendorContractPayment> => {
        return this.httpPost<VendorContractPayment>(`vendorContractPayment/${id}/transaction`, transaction);
    }

    update = (vendorContractPayment: VendorContractPayment): Observable<VendorContractPayment> => {
        return this.httpPut<VendorContractPayment>(`vendorContractPayment/${vendorContractPayment.id}`, vendorContractPayment);
    }

    delete = (id: string): Observable<VendorContractPayment> => {
        return this.httpDelete(`vendorContractPayment/${id}`);
    }
}
