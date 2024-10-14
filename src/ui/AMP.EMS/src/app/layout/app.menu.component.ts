import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { MenuItem } from 'primeng/api';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html',
})
export class AppMenuComponent implements OnInit {

    model: MenuItem[] = [];

    protected isAuthenticated: boolean = false;

    constructor(public layoutService: LayoutService, private oidcSecurityService: OidcSecurityService) { }

    ngOnInit() {
        this.oidcSecurityService.isAuthenticated$.subscribe(_ => {
            this.isAuthenticated = _.isAuthenticated;

            if (this.isAuthenticated) {
                this.model = [
                    {
                        label: 'Home',
                        items: [
                            { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] },
                            { label: 'Events', icon: 'pi pi-fw pi-calendar', routerLink: ['/events'] },
                            { label: 'Event Types', icon: 'pi pi-fw pi-cog', routerLink: ['/event-types'] },
                            { label: 'Guests', icon: 'pi pi-fw pi-users', routerLink: ['/guests'] },
                        ]
                    },
                    {
                        label: 'Profile',
                        items: [
                            {
                                label: 'Logout', icon: 'pi pi-sign-out', command: () => {
                                    this.logout()
                                },
                            },
                        ]
                    }
                ];
            }
            else {
                this.model = [
                    {
                        label: 'Profile',
                        items: [
                            {
                                label: 'Login', icon: 'pi pi-sign-in', command: () => {
                                    this.login()
                                },
                            },
                        ]
                    }
                ]
            }
        });
    }

    login(): void {
        this.oidcSecurityService.authorize();
    }

    logout(): void {
        this.oidcSecurityService.logoff().subscribe();
    }
}
