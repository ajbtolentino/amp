import { Component, OnInit, Signal } from '@angular/core';
import { AuthenticatedResult, EventTypes, LoginResponse, OidcClientNotification, OidcSecurityService, PublicEventsService, UserDataResult } from 'angular-auth-oidc-client';
import { filter, lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styles: ``
})
export class DefaultComponent implements OnInit {
  isAuthenticated$: Observable<AuthenticatedResult> = new Observable<AuthenticatedResult>();
  userData$: Observable<UserDataResult> = new Observable<UserDataResult>();
  notification$: Observable<OidcClientNotification<any>> = new Observable<OidcClientNotification<any>>();

  constructor(private oidcSecurityService: OidcSecurityService, private eventService: PublicEventsService) {
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
    this.userData$ = this.oidcSecurityService.userData$;
    this.notification$ = this.eventService.registerForEvents()
  }

  login = () => {
    this.oidcSecurityService.authorize();
  }

  logout = () => {
    lastValueFrom(this.oidcSecurityService.logoff());
  }
}
