import { Injectable } from '@angular/core';
import { BaseApiService } from './base.api.service';
import { lastValueFrom, Observable } from 'rxjs';
import { EventGuestRole, Role } from '@shared/models';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends BaseApiService {
  get = (id: string): Observable<EventGuestRole> => {
    return this.httpGet(`api/role/${id}`);
  }

  getAll = async () => {
    return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/role`, { headers: this.headers }));
  }

  add = (eventRole: EventGuestRole): Observable<EventGuestRole> => {
    return this.httpPost(`api/role`, eventRole);
  }

  update = (eventRole: Role): Observable<Role> => {
    return this.httpPut(`api/role/${eventRole.id}`, eventRole);
  }

  delete = (id: string): Observable<Role> => {
    return this.httpDelete(`api/role/${id}`);
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/role`, { headers: this.headers, body: ids }));
  }
}
