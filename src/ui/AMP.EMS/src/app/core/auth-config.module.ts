import { NgModule } from '@angular/core';
import { AbstractSecurityStorage, AuthModule, DefaultLocalStorageService, LogLevel } from 'angular-auth-oidc-client';
import { environment } from '../../environments/environment';


@NgModule({
    imports: [AuthModule.forRoot({
        config: {
            forbiddenRoute: '/forbidden',
            unauthorizedRoute: '/unauthorized',
            logLevel: LogLevel.Debug,
            authority: environment.IDP_AUTHORITY_HTTPS_URL,
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            clientId: environment.EMS_SPA_CLIENTID,
            scope: environment.EMS_SPA_CLIENTSCOPE,
            responseType: 'code',
            silentRenew: true,
            useRefreshToken: true,
            silentRenewUrl: environment.IDP_AUTHORITY_HTTPS_URL + "/connect/token"
        },
    })],
    providers: [
        {
            provide: AbstractSecurityStorage,
            useClass: DefaultLocalStorageService
        }
    ],
    exports: [AuthModule],
})
export class AuthConfigModule { }
