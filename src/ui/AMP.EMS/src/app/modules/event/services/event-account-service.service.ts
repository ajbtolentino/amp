import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services';
import { EventAccount } from '@shared/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventAccountServiceService extends BaseApiService {
  getById = (id: string): Observable<EventAccount> => {
    return this.httpGet(`eventaccount/${id}`);
  }

  getAll = (): Observable<EventAccount[]> => {
    return this.httpGet(`eventaccount`);
  }
}
