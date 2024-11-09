import { Injectable } from '@angular/core';
import { Vendor } from '@shared/models';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
  providedIn: 'root'
})
export class VendorService extends BaseApiService {
  get = (id: string): Observable<Vendor> => {
    return this.httpGet<Vendor>(`api/vendor/${id}`);
  }

  getByIds = (ids: string[]): Observable<Vendor[]> => {
    return this.httpGet<Vendor[]>(`api/vendor/getbyids`, { params: { ids: ids } });
  }

  getAll = (): Observable<Vendor[]> => {
    return this.httpGet<Vendor[]>(`api/vendor/`);
  }

  add = (vendor: Vendor): Observable<Vendor> => {
    return this.httpPost<Vendor>(`api/vendor`, vendor);
  }

  update = (vendor: Vendor): Observable<Vendor> => {
    return this.httpPut<Vendor>(`api/vendor`, vendor);
  }

  delete = (id: string): Observable<Vendor> => {
    return this.httpDelete(`api/vendor/${id}`);
  }
}
