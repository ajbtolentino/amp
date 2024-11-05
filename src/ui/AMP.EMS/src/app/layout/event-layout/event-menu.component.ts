import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { LayoutService } from '../service/app.layout.service';

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
                            label: 'Vendors',
                            icon: 'pi pi-fw pi-shop',
                            items: [
                                {
                                    label: 'Find Vendor',
                                    icon: 'pi pi-fw pi-search',
                                    routerLink: [`/event/${this.eventId}/vendors`]
                                },
                                {
                                    label: 'Transactions',
                                    icon: 'pi pi-fw pi-receipt',
                                    routerLink: [`/event/${this.eventId}/vendors/transactions`]
                                },
                                {
                                    label: 'Contracts',
                                    icon: 'pi pi-pen-to-square',
                                    routerLink: [`/event/${this.eventId}/vendors/contracts`]
                                }
                            ]
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
