import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { OidcSecurityService } from 'angular-auth-oidc-client';
import { lastValueFrom } from 'rxjs';
import { Guest } from './guest';

import { environment } from './../../environments/environment';

@Injectable()
export class GuestService {
    apiUrl: string = environment.apiUrl;
    headers: HttpHeaders | undefined;

    private readonly oidcSecurityService = inject(OidcSecurityService);

    constructor(private http: HttpClient) {
        this.oidcSecurityService.getAccessToken().subscribe(token =>
            this.headers = new HttpHeaders({
                Authorization: 'Bearer ' + token,
            }));
    }

    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.apiUrl}/api/guest`, { headers: this.headers }));
    }

    add = async (invitation: Guest) => {
        return await lastValueFrom(this.http.post<any>(`${this.apiUrl}/api/guest`, invitation, { headers: this.headers }));
    }

    update = async (invitation: Guest) => {
        return await lastValueFrom(this.http.put<any>(`${this.apiUrl}/api/guest/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.apiUrl}/api/guest/${id}`, { headers: this.headers }));
    }
}