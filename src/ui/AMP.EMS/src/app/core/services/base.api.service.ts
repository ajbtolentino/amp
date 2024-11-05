import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EMSResponse } from "@shared/models";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { map, Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable()
export class BaseApiService {
    headers: HttpHeaders | undefined;

    protected API_URL = environment.EMS_SPA_APIURL;

    constructor(protected httpClient: HttpClient, readonly oidcSecurityService: OidcSecurityService) {
        this.oidcSecurityService.getAccessToken().subscribe(token => {
            this.headers = new HttpHeaders({
                Authorization: 'Bearer ' + token,
            })
        });
    }

    protected httpGet = <T>(url: string, options?: any): Observable<T> => {
        return this.httpClient.get<EMSResponse<T>>(`${this.API_URL}/${url}`, { headers: this.headers, ...options }).pipe(map((a: any) => (a as EMSResponse<T>).data));
    }

    protected httpPost = <T>(url: string, body?: any): Observable<T> => {
        return this.httpClient.post<EMSResponse<T>>(`${this.API_URL}/${url}`, body, { headers: this.headers }).pipe(map((a: any) => (a as EMSResponse<T>).data));
    }

    protected httpPut = <T>(url: string, body?: any): Observable<T> => {
        return this.httpClient.put<EMSResponse<T>>(`${this.API_URL}/${url}`, body, { headers: this.headers }).pipe(map((a: any) => (a as EMSResponse<T>).data));
    }

    protected httpPatch = <T>(url: string, body?: any): Observable<T> => {
        return this.httpClient.patch<EMSResponse<T>>(`${this.API_URL}/${url}`, body, { headers: this.headers }).pipe(map((a: any) => (a as EMSResponse<T>).data));
    }

    protected httpDelete = <T>(url: string, options?: any): Observable<T> => {
        return this.httpClient.delete<EMSResponse<T>>(`${this.API_URL}/${url}`, { headers: this.headers, ...options }).pipe(map((a: any) => (a as EMSResponse<T>)?.data));
    }

    protected httpDeleteSelected = <T>(url: string, body: any[], options?: any): Observable<T> => {
        return this.httpClient.delete<EMSResponse<T>>(`${this.API_URL}/${url}`, { headers: this.headers, ...options, body: body }).pipe(map((a: any) => (a as EMSResponse<T>)?.data));
    }
}