import { Component, ElementRef, Input } from '@angular/core';
import { LayoutService } from "../service/app.layout.service";

@Component({
    selector: 'app-event-sidebar',
    templateUrl: './event-sidebar.component.html'
})
export class EventSidebarComponent {
    @Input() eventId!: string;

    constructor(public layoutService: LayoutService, public el: ElementRef) { }
}

