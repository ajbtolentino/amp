import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "../service/app.layout.service";
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-event-topbar',
    templateUrl: './event-topbar.component.html'
})
export class EventTopBarComponent {
    items!: MenuItem[];

    @Input() eventId!: string;

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private route: ActivatedRoute) { }
}
