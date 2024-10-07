import { Component, inject, CUSTOM_ELEMENTS_SCHEMA, OnInit } from '@angular/core';
import { EventTypes, OidcSecurityService, PublicEventsService } from 'angular-auth-oidc-client';
import { MenuItem } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import "primeicons/primeicons.css";

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})

export class NavigationComponent implements OnInit {
  items: MenuItem[] | undefined;
  profileItems: MenuItem[] | undefined;

  private readonly oidcSecurityService = inject(OidcSecurityService);
  private readonly eventService = inject(PublicEventsService);
  protected readonly authenticated = this.oidcSecurityService.authenticated;

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(() => this.refreshMenu());
  }

  refreshMenu = () => {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        routerLink: '/home'
      },
      {
        label: 'Events',
        icon: 'pi pi-star',
        routerLink: '/events',
        visible: this.authenticated().isAuthenticated
      }
    ];

    this.profileItems = [
      {
        label: 'Login',
        icon: 'pi pi-sign-in',
        visible: !this.authenticated().isAuthenticated,
        command: () => this.login()
      },
      {
        label: 'Logout',
        icon: 'pi pi-sign-out',
        visible: this.authenticated().isAuthenticated,
        command: () => this.logout()
      }
    ]
  }

  login(): void {
    this.oidcSecurityService.authorize();
  }

  logout(): void {
    this.oidcSecurityService.logoff().subscribe();
  }
}