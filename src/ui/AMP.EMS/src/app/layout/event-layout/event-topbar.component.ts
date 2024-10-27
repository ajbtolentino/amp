import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "../service/app.layout.service";
import { LoginResponse, OidcSecurityService } from 'angular-auth-oidc-client';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
    selector: 'app-event-topbar',
    templateUrl: './event-topbar.component.html'
})
export class EventTopBarComponent implements OnInit {
    auth$: Observable<LoginResponse> = new Observable<LoginResponse>();

    items!: MenuItem[];

    @Input() eventId!: string;

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private oidcSecurityService: OidcSecurityService) { }

    menuItems: MenuItem[] = [];

    ngOnInit(): void {
        this.auth$ = this.oidcSecurityService.checkAuth();
    }

    login = async () => {
        this.oidcSecurityService.authorize();
    }

    logout = async () => {
        await lastValueFrom(this.oidcSecurityService.logoff());
    }
}
