import { Component, OnInit } from '@angular/core';
import { AuthenticatedResult, AuthWellKnownEndpoints, OidcClientNotification, OidcSecurityService, PublicEventsService, UserDataResult } from 'angular-auth-oidc-client';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ``
})
export class HomeComponent implements OnInit {
  isAuthenticated$: Observable<AuthenticatedResult> = new Observable<AuthenticatedResult>();
  userData$: Observable<UserDataResult> = new Observable<UserDataResult>();
  notification$: Observable<OidcClientNotification<any>> = new Observable<OidcClientNotification<any>>();
  isLoading$: Observable<boolean> = new Observable<boolean>();
  authWellKnownEndpoints$: Observable<AuthWellKnownEndpoints> = new Observable<AuthWellKnownEndpoints>();
  constructor(private oidcSecurityService: OidcSecurityService, private publicEventsService: PublicEventsService) {
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
    this.userData$ = this.oidcSecurityService.userData$;
    this.authWellKnownEndpoints$ = this.oidcSecurityService.preloadAuthWellKnownDocument()
    this.notification$ = this.publicEventsService.registerForEvents()
  }

  login = () => {
    this.oidcSecurityService.authorize();
  }

  logout = () => {
    lastValueFrom(this.oidcSecurityService.logoff());
  }
}
