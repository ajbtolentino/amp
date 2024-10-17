import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-event-invitation-template-editor',
  templateUrl: './event-invitation-template-editor.component.html',
  styles: `.ql-container{ font-family: 'monospace' !important }`
})
export class EventInvitationTemplateEditorComponent {
  @Input() templateCode!: string;
  @Output() templateCodeChange: EventEmitter<string> = new EventEmitter<string>();

  onTemplateCodeChange(e: any) {
    console.log(e);
    this.templateCodeChange.emit(e.textValue);
  }
}
