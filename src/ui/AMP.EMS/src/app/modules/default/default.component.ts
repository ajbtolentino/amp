import { Component, OnInit, Signal } from '@angular/core';
import { AuthenticatedResult, LoginResponse, OidcClientNotification, OidcSecurityService, PublicEventsService } from 'angular-auth-oidc-client';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styles: ``
})
export class DefaultComponent implements OnInit {
  isAuthenticated$: Observable<AuthenticatedResult> = new Observable<AuthenticatedResult>();

  constructor(private oidcSecurityService: OidcSecurityService) {
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
  }

  login = () => {
    this.oidcSecurityService.authorize();
  }

  logout = () => {
    lastValueFrom(this.oidcSecurityService.logoff());
  }
}
