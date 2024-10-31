import { Injectable } from '@angular/core';
import { BaseApiService } from './base.api.service';
import { lastValueFrom, Observable } from 'rxjs';
import { EventGuestRole } from '../models/event-guest-role';
import { EventRole } from '../models/event-role';

@Injectable({
  providedIn: 'root'
})
export class EventRoleService extends BaseApiService {
  get = (id: string): Observable<EventGuestRole> => {
    return this.httpGet(`api/eventrole/${id}`);
  }

  getAll = async () => {
    return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventrole`, { headers: this.headers }));
  }

  add = (eventRole: EventGuestRole): Observable<EventGuestRole> => {
    return this.httpPost(`api/eventrole`, eventRole);
  }

  update = (eventRole: EventRole): Observable<EventRole> => {
    return this.httpPut(`api/eventrole/${eventRole.id}`, eventRole);
  }

  delete = (id: string): Observable<EventRole> => {
    return this.httpDelete(`api/eventrole/${id}`);
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL} / api / eventrole`, { headers: this.headers, body: ids }));
  }
}
