import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Event } from '../models/event';
import { lastValueFrom, Observable } from 'rxjs';

import { BaseApiService } from './base.api.service';
import { EventType } from '../models/event-type';

@Injectable({
    providedIn: 'root'
})
export class EventTypeService extends BaseApiService {
    get = (id: string): Observable<EventType> => {
        return this.httpGet<EventType>(`api/eventtype/${id}`);
    }

    getAll = (options?: any): Observable<EventType[]> => {
        return this.httpGet<EventType[]>(`api/eventtype`, options);
    }

    add = (event: Event): Observable<Event> => {
        return this.httpPost<Event>(`api/eventtype`, event);
    }

    update = (event: Event): Observable<Event> => {
        return this.httpPut<Event>(`api/eventtype/${event.id}`, event);
    }

    delete = (id: string): Observable<Event> => {
        return this.httpDelete<Event>(`api/eventtype/${id}`);
    }

    deleteSelected = (ids: string[]) => {
        return this.httpDelete(`api/eventtype`, { body: ids });
    }
}