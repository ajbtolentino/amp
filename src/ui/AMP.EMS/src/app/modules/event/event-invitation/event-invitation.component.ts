import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { EventInvitation } from '../../../core/models/event-invitation';
import { EventInvitationService } from '../../../core/services/event-invitation.service';
import { CodeEditorComponent, CodeModel } from '@ngstack/code-editor';
import { EventGuestInvitationRSVP } from '../../../core/models/event-guest-invitation-rsvp';

@Component({
  selector: 'app-event-invitation',
  templateUrl: './event-invitation.component.html',
  styles: ``,
})
export class EventInvitationComponent implements OnInit {
  eventInvitation: EventInvitation = {};

  loading: boolean = false;

  eventId!: string;

  theme: string = "vs-dark"

  model: CodeModel = {
    language: 'html',
    uri: 'main.html',
    value: '',
    dependencies: [
      '@ngstack/translate',
      '@ngstack/code-editor'
    ]
  };

  options = {
    contextmenu: true,
    automaticLayout: true,
    minimap: {
      enabled: false
    }
  };

  @ViewChild('codeEditor', { static: false }) codeEditor!: CodeEditorComponent;

  constructor(private eventInvitationService: EventInvitationService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) this.eventId = eventId;
    });
  }

  onEditorLoaded() {
    this.route.paramMap.subscribe(data => {
      const eventInvitationId = data.get("eventInvitationId");

      if (eventInvitationId) this.loadEventInvitation(eventInvitationId);
    });
  }

  loadEventInvitation = async (eventInvitationId: string) => {
    this.loading = true;

    const response = await this.eventInvitationService.get(eventInvitationId);

    if (response.data) {
      this.eventInvitation = response.data;
      this.codeEditor.editor.setValue(this.eventInvitation.html || '');
    }

    this.loading = false;
  }

  onCodeChanged(e: any) {
    this.eventInvitation.html = e;
  }

  save = async () => {
    if (this.eventInvitation?.name?.trim()) {
      this.loading = true;

      if (this.eventInvitation.id) {
        await this.eventInvitationService.update(this.eventInvitation);
      }
      else {
        this.eventInvitation.eventId = this.eventId;

        await this.eventInvitationService.add(this.eventInvitation);
      }

      this.loading = false;

      this.router.navigate([`/event/${this.eventId}/invitations`]);
    }
  }

  onRsvpSubmit = () => {
    alert('Response Submitted!');
  }
}
