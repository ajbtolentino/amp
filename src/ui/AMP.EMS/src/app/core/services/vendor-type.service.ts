import { Injectable } from '@angular/core';
import { VendorType } from '@shared/models/vendor-type.model';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class VendorTypeService extends BaseApiService {
    get = (id: string): Observable<VendorType> => {
        return this.httpGet<VendorType>(`api/vendortype/${id}`);
    }

    getAll = (): Observable<VendorType[]> => {
        return this.httpGet<VendorType[]>(`api/vendortype/`);
    }

    getByIds = (ids: string[]): Observable<VendorType[]> => {
        return this.httpGet<VendorType[]>(`api/vendortype/getbyids`, { params: { ids: ids } });
    }

    add = (vendorType: VendorType): Observable<VendorType> => {
        return this.httpPost<VendorType>(`api/vendortype`, vendorType);
    }

    update = (vendorType: VendorType): Observable<VendorType> => {
        return this.httpPut<VendorType>(`api/vendortype`, vendorType);
    }

    delete = (id: string): Observable<VendorType> => {
        return this.httpDelete(`api/vendortype/${id}`);
    }
}
