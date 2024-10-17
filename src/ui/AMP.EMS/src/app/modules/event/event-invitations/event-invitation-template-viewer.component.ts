import { Component } from '@angular/core';
import { Directive, Type, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appAdhost]'
})
export class AdhostDirective {
  constructor(public viewContainerRef: ViewContainerRef) {
  }
}

@Component({
  selector: 'app-event-invitation-template-viewer',
  templateUrl: './event-invitation-template-viewer.component.html',
  styles: ``
})
export class EventInvitationTemplateViewerComponent {

}
