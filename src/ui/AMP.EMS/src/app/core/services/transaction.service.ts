import { Injectable } from '@angular/core';
import { Transaction } from '@shared/models';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
  providedIn: 'root'
})
export class TransactionService extends BaseApiService {
  get = (id: string): Observable<Transaction> => {
    return this.httpGet<Transaction>(`transaction/${id}`);
  }

  getByIds = (ids: string[]): Observable<Transaction[]> => {
    return this.httpGet<Transaction[]>(`transaction/getbyids`, { params: { ids: ids } });
  }

  getAll = (): Observable<Transaction[]> => {
    return this.httpGet<Transaction[]>(`transaction/`);
  }

  add = (transaction: Transaction): Observable<Transaction> => {
    return this.httpPost<Transaction>(`transaction/`, transaction);
  }

  update = (transaction: Transaction): Observable<Transaction> => {
    return this.httpPut<Transaction>(`transaction/${transaction.id}`, transaction);
  }

  delete = (id: string): Observable<Transaction> => {
    return this.httpDelete(`event/${id}`);
  }
}
