import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { OidcSecurityService } from 'angular-auth-oidc-client';
import { lastValueFrom } from 'rxjs';
import { Invitation } from './invitation';

import { environment } from './../../environments/environment';

@Injectable()
export class InvitationService {
    apiUrl: string = environment.apiUrl;
    headers: HttpHeaders | undefined;

    private readonly oidcSecurityService = inject(OidcSecurityService);

    constructor(private http: HttpClient) {
        this.oidcSecurityService.getAccessToken().subscribe(token =>
            this.headers = new HttpHeaders({
                Authorization: 'Bearer ' + token,
            }));
    }

    getAll = async (eventId: string) => {
        return await lastValueFrom(this.http.get<any>(`${this.apiUrl}/api/invitation/${eventId}/details`, { headers: this.headers }));
    }

    add = async (invitation: Invitation) => {
        return await lastValueFrom(this.http.post<any>(`${this.apiUrl}/api/invitation`, invitation, { headers: this.headers }));
    }

    update = async (invitation: Invitation) => {
        return await lastValueFrom(this.http.put<any>(`${this.apiUrl}/api/invitation/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.apiUrl}/api/invitation/${id}`, { headers: this.headers }));
    }
}