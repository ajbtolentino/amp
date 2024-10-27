import { Injectable } from '@angular/core';
import { BaseApiService } from './base.api.service';
import { lastValueFrom, Observable } from 'rxjs';
import { EventGuestRole } from '../models/event-guest-role';

@Injectable({
  providedIn: 'root'
})
export class EventGuestRoleService extends BaseApiService {
  get = (id: string): Observable<EventGuestRole> => {
    return this.httpGet(`api/eventguestrole/${id}`);
  }

  getAll = async () => {
    return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventguestrole`, { headers: this.headers }));
  }

  add = (eventRole: EventGuestRole): Observable<EventGuestRole> => {
    return this.httpPost(`api/eventguestrole`, eventRole);
  }

  update = (eventRole: EventGuestRole): Observable<EventGuestRole> => {
    return this.httpPut(`api/eventguestrole/${eventRole.id}`);
  }

  delete = async (id: string) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL} / api / eventguestrole / ${id}`, { headers: this.headers }));
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL} / api / eventguestrole`, { headers: this.headers, body: ids }));
  }
}
