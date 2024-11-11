import { Injectable } from '@angular/core';
import { Vendor } from '@shared/models';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
  providedIn: 'root'
})
export class VendorService extends BaseApiService {
  get = (id: string): Observable<Vendor> => {
    return this.httpGet<Vendor>(`vendor/${id}`);
  }

  getByIds = (ids: string[]): Observable<Vendor[]> => {
    return this.httpGet<Vendor[]>(`vendor/getbyids`, { params: { ids: ids } });
  }

  getAll = (): Observable<Vendor[]> => {
    return this.httpGet<Vendor[]>(`vendor/`);
  }

  add = (vendor: Vendor): Observable<Vendor> => {
    return this.httpPost<Vendor>(`vendor`, vendor);
  }

  update = (vendor: Vendor): Observable<Vendor> => {
    return this.httpPut<Vendor>(`vendor/${vendor.id}`, vendor);
  }

  delete = (id: string): Observable<Vendor> => {
    return this.httpDelete(`vendor/${id}`);
  }
}
