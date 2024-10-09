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
  menuItems: MenuItem[] | undefined;
  accountItems: MenuItem[] | undefined;
  profileInitials: string | undefined;

  private readonly oidcSecurityService = inject(OidcSecurityService);
  protected readonly authenticated = this.oidcSecurityService.authenticated;

  ngOnInit() {
    this.oidcSecurityService.isAuthenticated$.subscribe(() => this.refreshMenu());
    this.oidcSecurityService.userData$.subscribe(data => {
      this.profileInitials = '';

      if (data?.userData?.given_name) {
        this.profileInitials += data.userData.given_name[0];
      }

      if (data?.userData?.family_name) {
        this.profileInitials += data.userData.family_name[0];
      }
    });
  }

  refreshMenu = () => {
    this.menuItems = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        routerLink: '/home'
      },
      {
        label: 'Events',
        icon: 'pi pi-calendar',
        routerLink: '/events',
        visible: this.authenticated().isAuthenticated
      },
      {
        label: 'Guests',
        icon: 'pi pi-users',
        routerLink: '/guests',
        visible: this.authenticated().isAuthenticated
      }
    ];

    this.accountItems = [
      {
        label: 'Account',
        items: [
          {
            label: 'Profile',
            icon: 'pi pi-sign-in',
            visible: this.authenticated().isAuthenticated
          },
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
    ]
  }

  login(): void {
    this.oidcSecurityService.authorize();
  }

  logout(): void {
    this.oidcSecurityService.logoff().subscribe();
  }
}