import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appEventInvitationTemplateViewer]'
})
export class EventInvitationTemplateViewerDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }

}
