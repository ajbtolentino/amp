import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Event } from './event';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { lastValueFrom } from 'rxjs';

import { environment } from './../../environments/environment';

@Injectable()
export class EventService {
    apiUrl: string = environment.apiUrl;
    headers: HttpHeaders | undefined;

    private readonly oidcSecurityService = inject(OidcSecurityService);

    constructor(private http: HttpClient) {
        this.oidcSecurityService.getAccessToken().subscribe(token =>
            this.headers = new HttpHeaders({
                Authorization: 'Bearer ' + token,
            }));
    }

    get = async (id: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.apiUrl}/api/event/${id}`, { headers: this.headers }));
    }

    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.apiUrl}/api/event`, { headers: this.headers }));
    }

    add = async (event: Event) => {
        return await lastValueFrom(this.http.post<any>(`${this.apiUrl}/api/event`, event, { headers: this.headers }));
    }

    update = async (event: Event) => {
        return await lastValueFrom(this.http.put<any>(`${this.apiUrl}/api/event/${event.id}`, event, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.apiUrl}/api/event/${id}`, { headers: this.headers }));
    }
}