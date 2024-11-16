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
                            routerLink: [`dashboard`]
                        },
                        {
                            label: 'Guests',
                            icon: 'pi pi-fw pi-users',
                            routerLink: [`guests`]
                        },
                        {
                            label: 'Invitations',
                            icon: 'pi pi-fw pi-envelope',
                            routerLink: [`invitations`],
                        },
                        {
                            label: 'Vendors',
                            icon: 'pi pi-fw pi-shop',
                            items: [
                                {
                                    label: 'Search',
                                    icon: 'pi pi-fw pi-search',
                                    routerLink: [`vendors`]
                                },
                                {
                                    label: 'Contracts',
                                    icon: 'pi pi-fw pi-file-edit',
                                    routerLink: ['vendors', 'contracts']
                                }
                            ]
                        },
                        {
                            label: 'Accounts',
                            icon: 'pi pi-fw pi-id-card',
                            routerLink: ['accounts'],
                            items: [
                                {
                                    label: 'Manage',
                                    icon: 'pi pi-fw pi-wrench',
                                    routerLink: ['accounts']
                                },
                                {
                                    label: 'Setup Budget',
                                    icon: 'pi pi-fw pi-calculator',
                                    routerLink: ['budgets']
                                },
                                {
                                    label: 'Transactions',
                                    icon: 'pi pi-fw pi-money-bill',
                                    routerLink: ['transactions']
                                }
                            ]
                        },
                        {
                            label: 'Scheduling',
                            icon: 'pi pi-fw pi-calendar-clock',
                            items: [
                                {
                                    label: 'Manage Timeline',
                                    icon: 'pi pi-fw pi-list'
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
                            routerLink: ['edit']
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
