import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Event } from '../models/event';
import { lastValueFrom } from 'rxjs';

import { BaseService } from './base.service';

@Injectable()
export class EventService extends BaseService {
    get = async (id: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
    }

    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/event`, { headers: this.headers }));
    }

    add = async (event: Event) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/event`, event, { headers: this.headers }));
    }

    update = async (event: Event) => {
        return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/event/${event.id}`, event, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/event/${id}`, { headers: this.headers }));
    }
}