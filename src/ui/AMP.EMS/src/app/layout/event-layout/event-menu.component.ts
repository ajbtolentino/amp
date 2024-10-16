import { Input, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../service/app.layout.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { MenuItem } from 'primeng/api';
import { ActivatedRoute, ActivationEnd, NavigationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs';

@Component({
    selector: 'app-event-menu',
    templateUrl: './event-menu.component.html',
})
export class EventMenuComponent implements OnInit {
    model: MenuItem[] = [];

    @Input() eventId!: string;

    protected isAuthenticated: boolean = false;

    constructor(public layoutService: LayoutService,
        private route: ActivatedRoute) { }

    ngOnInit(): void {
        if (this.eventId) {
            this.model = [
                {
                    label: 'Home',
                    items: [
                        {
                            label: 'Dashboard',
                            icon: 'pi pi-fw pi-home',
                            routerLink: [`/event/${this.eventId}/dashboard`]
                        },
                        {
                            label: 'Guests',
                            icon: 'pi pi-fw pi-users',
                            routerLink: [`/event/${this.eventId}/guests`]
                        },
                        {
                            label: 'Invitations',
                            icon: 'pi pi-fw pi-paperclip',
                            routerLink: [`/event/${this.eventId}/invitations`]
                        },
                    ]
                },
                {
                    label: 'Accounting',
                    items: [
                        { label: 'Transactions', icon: 'pi pi-fw pi-dollar', },
                        { label: 'Budget', icon: 'pi pi-fw pi-calculator', },
                    ]
                }
            ];
        }
    }
}
