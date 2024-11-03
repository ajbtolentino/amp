import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';
import { Vendor } from '@shared/models/vendor-model';

@Injectable({
  providedIn: 'root'
})
export class VendorService extends BaseApiService {
  get = (id: string): Observable<Vendor> => {
    return this.httpGet<Vendor>(`api/vendor/${id}`);
  }

  getAll = (): Observable<Vendor[]> => {
    return this.httpGet<Vendor[]>(`api/vendor/`);
  }

  add = (vendor: Vendor): Observable<Vendor> => {
    return this.httpPost<Vendor>(`api/vendor`, vendor);
  }

  update = (transaction: Vendor): Observable<Vendor> => {
    return this.httpPut<Vendor>(`api/vendor`, transaction);
  }

  delete = (id: string): Observable<Vendor> => {
    return this.httpDelete(`api/vendor/${id}`);
  }
}
