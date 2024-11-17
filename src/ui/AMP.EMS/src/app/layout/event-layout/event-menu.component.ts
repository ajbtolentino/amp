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
                            label: 'Planning',
                            icon: 'pi pi-fw pi-clipboard',
                            items: [
                                {
                                    label: 'Timeline',
                                    icon: 'pi pi-fw pi-calendar-clock',
                                    routerLink: ['timeline']
                                },
                                {
                                    label: 'Tasks',
                                    icon: 'pi pi-fw pi-list-check',
                                    routerLink: ['tasks']
                                },
                                {
                                    label: 'Seat Assignments',
                                    icon: 'pi pi-fw pi-sitemap',
                                    routerLink: ['seat-assignment']
                                }
                            ]
                        },
                        {
                            label: 'Guests',
                            icon: 'pi pi-fw pi-users',
                            items: [
                                {
                                    label: 'Manage',
                                    icon: 'pi pi-fw pi-wrench',
                                    routerLink: [`guests`]
                                },
                                {
                                    label: 'Invitations',
                                    icon: 'pi pi-fw pi-envelope',
                                    routerLink: [`invitations`],
                                }
                            ]
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
