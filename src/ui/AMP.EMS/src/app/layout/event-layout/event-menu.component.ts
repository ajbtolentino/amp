import { Input, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../service/app.layout.service';
import { MenuItem } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-event-menu',
    templateUrl: './event-menu.component.html',
})
export class EventMenuComponent implements OnInit {
    model: MenuItem[] = [];

    @Input() eventId!: string;

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
                            label: 'Vendors',
                            icon: 'pi pi-fw pi-shopping-bag',
                            routerLink: [`/event/${this.eventId}/vendors`]
                        },
                        {
                            label: 'Guests',
                            icon: 'pi pi-fw pi-users',
                            routerLink: [`/event/${this.eventId}/guests`]
                        },
                        {
                            label: 'Invitations',
                            icon: 'pi pi-fw pi-envelope',
                            routerLink: [`/event/${this.eventId}/invitations`],
                        },
                        {
                            label: 'Budget Management',
                            icon: 'pi pi-fw pi-calculator',
                            items: [
                                {
                                    label: 'View Budgets',
                                    routerLink: [`/event/${this.eventId}/budget`]
                                },
                                {
                                    label: 'Expense Tracking',
                                    routerLink: [`/event/${this.eventId}/transactions`]
                                }
                            ]
                        }
                    ]
                },
                {
                    label: 'Settings',
                    items: [
                        {
                            label: 'Edit Event',
                            icon: 'pi pi-fw pi-cog',
                            routerLink: [`/event/${this.eventId}/edit`]
                        },
                        {
                            label: 'Logout',
                            icon: 'pi pi-fw pi-sign-out',
                        },
                    ]
                }
            ];
        }
    }
}
