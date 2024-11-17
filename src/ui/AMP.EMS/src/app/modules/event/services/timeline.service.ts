import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Timeline } from '@shared/models/timeline.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class TimelineService extends BaseApiService {
    get = (id: string): Observable<Timeline> => {
        return this.httpGet(`timeline/${id}`);
    }

    getAll = (): Observable<Timeline[]> => {
        return this.httpGet<Timeline[]>(`timeline`);
    }

    getByIds = (ids: string[]) => {
        return this.httpGet<Timeline[]>(`timeline/getbyids`, { params: { ids: ids } });
    }

    add = (timeline: Timeline): Observable<Timeline> => {
        return this.httpPost(`timeline`, timeline);
    }

    update = (timeline: Timeline): Observable<Timeline> => {
        return this.httpPut(`timeline/${timeline.id}`, timeline);
    }

    delete = (id: string): Observable<Timeline> => {
        return this.httpDelete<Timeline>(`timeline/${id}`);
    }

    deleteSelected = (ids: string[]): Observable<Timeline[]> => {
        return this.httpDeleteSelected(`timeline`, ids);
    }
}