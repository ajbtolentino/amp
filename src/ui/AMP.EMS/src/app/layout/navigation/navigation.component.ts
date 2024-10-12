import { Component, inject, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { MenuItem } from 'primeng/api';
import "primeicons/primeicons.css";
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss',
  imports: [
    MenubarModule,
    ButtonModule,
    CommonModule
  ]
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
        icon: 'pi pi-home',
        routerLink: '/'
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