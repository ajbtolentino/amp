import { Injectable } from '@angular/core';
import { Content } from '@shared/models/content.model';
import { Observable } from 'rxjs';
import { BaseApiService } from './base.api.service';

@Injectable({
    providedIn: 'root'
})
export class ContentService extends BaseApiService {
    get = (id: string): Observable<Content> => {
        return this.httpGet<Content>(`content/${id}`);
    }

    getAll = (): Observable<Content[]> => {
        return this.httpGet<Content[]>(`content/`);
    }

    add = (content: Content): Observable<Content> => {
        return this.httpPost<Content>(`content`, content);
    }

    update = (content: Content): Observable<Content> => {
        return this.httpPut<Content>(`content`, content);
    }

    delete = (id: string): Observable<Content> => {
        return this.httpDelete(`content/${id}`);
    }
}
