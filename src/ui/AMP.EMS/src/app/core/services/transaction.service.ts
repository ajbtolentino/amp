import { Injectable } from '@angular/core';
import { BaseApiService } from './base.api.service';
import { Observable } from 'rxjs';
import { Transaction } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService extends BaseApiService {
  get = (id: string): Observable<Transaction> => {
    return this.httpGet<Transaction>(`api/transaction/${id}`);
  }

  getAll = (): Observable<Transaction[]> => {
    return this.httpGet<Transaction[]>(`api/transaction/`);
  }

  add = (transaction: Transaction): Observable<Transaction> => {
    return this.httpPost<Transaction>(`api/transaction`, transaction);
  }

  update = (transaction: Transaction): Observable<Transaction> => {
    return this.httpPut<Transaction>(`api/transaction`, transaction);
  }

  delete = (id: string): Observable<Transaction> => {
    return this.httpDelete(`api/event/${id}`);
  }
}
