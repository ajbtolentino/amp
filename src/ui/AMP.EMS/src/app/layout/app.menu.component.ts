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
                            {
                                label: 'Manage', icon: 'pi pi-fw pi-table',
                                items: [
                                    {
                                        label: 'Events',
                                        icon: 'pi pi-fw pi-calendar',
                                        routerLink: ['/events']
                                    },
                                    {
                                        label: 'Guests',
                                        icon: 'pi pi-fw pi-users',
                                        routerLink: ['/guests']
                                    },
                                    {
                                        label: 'Invitations',
                                        icon: 'pi pi-fw pi-paperclip',
                                        routerLink: ['/event/invitations']
                                    }
                                ]
                            },
                            { label: 'Configuration', icon: 'pi pi-fw pi-cog', routerLink: ['/configuration'] },
                        ]
                    },
                    {
                        label: 'Accounting',
                        items: [
                            { label: 'Transactions', icon: 'pi pi-fw pi-dollar', },
                            { label: 'Budget', icon: 'pi pi-fw pi-calculator', },
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
