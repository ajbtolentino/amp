import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { Transaction, VendorContractPayment } from '@shared/models';
import { VendorContract } from '@shared/models/event-vendor-contract.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class VendorContractService extends BaseApiService {
    get = (id: string): Observable<VendorContract> => {
        return this.httpGet<VendorContract>(`vendorcontract/${id}`);
    }

    getTransactions = (id: string): Observable<Transaction[]> => {
        return this.httpGet<Transaction[]>(`vendorcontract/${id}/transactions`);
    }

    getByVendorIds = (vendorIds: string[]): Observable<VendorContract[]> => {
        return this.httpGet<VendorContract[]>(`vendorcontract/getbyvendorids`, { params: { vendorIds: vendorIds } });
    }

    getByIds = (ids: string[]): Observable<VendorContract[]> => {
        return this.httpGet<VendorContract[]>(`vendorcontract/`, { params: { ids: ids } });
    }

    getAll = (): Observable<VendorContract[]> => {
        return this.httpGet<VendorContract[]>(`vendorcontract/`);
    }

    getPayments = (id: string): Observable<VendorContractPayment[]> => {
        return this.httpGet<VendorContract[]>(`vendorcontract/${id}/payments`);
    }

    add = (vendorContract: VendorContract): Observable<VendorContract> => {
        return this.httpPost<VendorContract>(`vendorcontract`, vendorContract);
    }

    update = (vendorContract: VendorContract): Observable<VendorContract> => {
        return this.httpPut<VendorContract>(`vendorcontract/${vendorContract.id}`, vendorContract);
    }

    delete = (id: string): Observable<VendorContract> => {
        return this.httpDelete(`vendorcontract/${id}`);
    }
}
