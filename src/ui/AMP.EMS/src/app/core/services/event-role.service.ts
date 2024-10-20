import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { lastValueFrom } from 'rxjs';
import { EventRole } from '../models/event-role';

@Injectable({
  providedIn: 'root'
})
export class EventRoleService extends BaseService {
  get = async (id: string) => {
    return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventrole/${id}`, { headers: this.headers }));
  }

  getAll = async () => {
    return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/eventrole`, { headers: this.headers }));
  }

  add = async (eventRole: EventRole) => {
    return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/eventrole`, eventRole, { headers: this.headers }));
  }

  update = async (eventRole: EventRole) => {
    return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/eventrole/${eventRole.id}`, event, { headers: this.headers }));
  }

  delete = async (id: string) => {
    return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/eventrole/${id}`, { headers: this.headers }));
  }

  deleteSelected = async (ids: string[]) => {
    return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/eventrole`, { headers: this.headers, body: ids }));
  }
}
