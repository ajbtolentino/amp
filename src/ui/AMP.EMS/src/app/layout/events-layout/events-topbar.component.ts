import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "../service/app.layout.service";
import { LoginResponse, OidcSecurityService } from "angular-auth-oidc-client";
import { lastValueFrom, Observable } from 'rxjs';

@Component({
    selector: 'app-events-topbar',
    styles: ['.layout-topbar { justify-content : end }'],
    templateUrl: './events-topbar.component.html'
})
export class EventsTopBarComponent implements OnInit {
    auth$: Observable<LoginResponse> = new Observable<LoginResponse>();

    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private oidcSecurityService: OidcSecurityService) { }

    ngOnInit(): void {
        this.auth$ = this.oidcSecurityService.checkAuth();
    }

    login = () => {
        this.oidcSecurityService.authorize();
    }

    logout = async () => {
        await lastValueFrom(this.oidcSecurityService.logoff());
    }
}
