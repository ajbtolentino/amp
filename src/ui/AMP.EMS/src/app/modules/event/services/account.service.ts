import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { Account } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseApiService {
  getById = (id: string): Observable<Account> => {
    return this.httpGet(`account/${id}`);
  }

  getByIds = (ids: string[]): Observable<Account[]> => {
    return this.httpGet(`account/getbyids`, { params: { ids: ids } });
  }

  getAll = (): Observable<Account[]> => {
    return this.httpGet(`account`);
  }
}
