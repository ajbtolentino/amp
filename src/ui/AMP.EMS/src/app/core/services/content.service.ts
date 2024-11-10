import { Injectable } from '@angular/core';
import { Content } from '@shared/models/content.model';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class ContentService extends BaseApiService {
    get = (id: string): Observable<Content> => {
        return this.httpGet<Content>(`api/content/${id}`);
    }

    getAll = (): Observable<Content[]> => {
        return this.httpGet<Content[]>(`api/content/`);
    }

    add = (content: Content): Observable<Content> => {
        return this.httpPost<Content>(`api/content`, content);
    }

    update = (content: Content): Observable<Content> => {
        return this.httpPut<Content>(`api/content`, content);
    }

    delete = (id: string): Observable<Content> => {
        return this.httpDelete(`api/content/${id}`);
    }
}
