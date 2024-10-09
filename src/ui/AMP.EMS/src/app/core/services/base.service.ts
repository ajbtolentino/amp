import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { OidcSecurityService } from "angular-auth-oidc-client";

@Injectable()
export class BaseService {
    headers: HttpHeaders | undefined;

    protected API_URL = environment.EMS_SPA_APIURL;
    protected readonly oidcSecurityService = inject(OidcSecurityService);

    constructor(protected http: HttpClient) {
        this.oidcSecurityService.getAccessToken().subscribe(token =>
            this.headers = new HttpHeaders({
                Authorization: 'Bearer ' + token,
            }));
    }
}