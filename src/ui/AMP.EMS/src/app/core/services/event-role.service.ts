import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { lastValueFrom } from 'rxjs';
import { EventRole } from '../models/event-role';

@Injectable({
  providedIn: 'root'
})
export class EventRoleService extends BaseService {
  get = async (id: string) => {
    return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventrole/${id}`, { headers: this.headers }));
  }

  getAll = async () => {
    return await lastValueFrom(this.httpClient.get<any>(`${this.API_URL}/api/eventrole`, { headers: this.headers }));
  }

  add = async (eventRole: EventRole) => {
    return await lastValueFrom(this.httpClient.post<any>(`${this.API_URL}/api/eventrole`, eventRole, { headers: this.headers }));
  }

  update = async (eventRole: EventRole) => {
    return await lastValueFrom(this.httpClient.put<any>(`${this.API_URL}/api/eventrole/${eventRole.id}`, eventRole, { headers: this.headers }));
  }

  delete = async (id: string) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/eventrole/${id}`, { headers: this.headers }));
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.httpClient.delete<any>(`${this.API_URL}/api/eventrole`, { headers: this.headers, body: ids }));
  }
}
