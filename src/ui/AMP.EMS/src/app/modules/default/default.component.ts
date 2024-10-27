import { Component, OnInit } from '@angular/core';
import { LoginResponse, OidcSecurityService } from 'angular-auth-oidc-client';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styles: ``
})
export class DefaultComponent implements OnInit {
  isAuthenticated$: Observable<LoginResponse> = new Observable<LoginResponse>();

  constructor(private oidcSecurityService: OidcSecurityService) {
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.oidcSecurityService.checkAuth();
  }

  login = () => {
    this.oidcSecurityService.authorize();
  }

  logout = () => {
    lastValueFrom(this.oidcSecurityService.logoff());
  }
}
