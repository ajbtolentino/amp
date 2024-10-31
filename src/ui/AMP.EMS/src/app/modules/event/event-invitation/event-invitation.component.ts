import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { EventInvitation } from '../../../core/models/event-invitation';
import { EventInvitationService } from '../../../core/services/event-invitation.service';
import { CodeEditorComponent, CodeModel } from '@ngstack/code-editor';
import { EventGuestInvitationRsvp } from '../../../core/models/event-guest-invitation-rsvp';
import { Observable } from 'rxjs';
import { EventGuestInvitationInfo } from '../../../core/models/event-invitation-info';
import { Guest } from '../../../core/models/guest';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';

@Component({
  selector: 'app-event-invitation',
  templateUrl: './event-invitation.component.html',
  styles: `.invitation-badge {
    border-radius: var(--border-radius);
    padding: .25em .5rem;
    text-transform: uppercase;
    font-weight: 700;
    font-size: 12px;
    letter-spacing: .3px;

    &.status-missing-invitation {
        background: #FEEDAF;
        color: #8A5340;
    }

    &.status-awaiting-response {
        background: #ECCFFF;
        color: #694382;
    }

    &.status-responded {
        background: #B3E5FC;
        color: #23547B;
    }

    &.status-ACCEPT {
        background: #C8E6C9 !important;
        color: #256029 !important;
    }

    &.status-new {
        background: #B3E5FC;
        color: #23547B;
    }

    &.status-DECLINE {
        background: #FFCDD2;
        color: #C63737;
    }
}`,
})
export class EventInvitationComponent implements OnInit {
  eventInvitation: EventInvitation = {};
  eventInvitation$: Observable<EventInvitation> = new Observable<EventInvitation>();
  eventGuestInvitations$: Observable<EventGuestInvitation[]> = new Observable<EventGuestInvitation[]>();

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
    const eventInvitationId = this.route.snapshot.paramMap.get("eventInvitationId") || '';
    if (eventInvitationId) this.loadEventInvitation(eventInvitationId);
  }

  loadEventInvitation = async (eventInvitationId: string) => {
    this.eventInvitationService.get(eventInvitationId).subscribe(response => {
      this.eventInvitation = response;
      this.codeEditor.editor.setValue(this.eventInvitation.html || '');
    });

    this.eventGuestInvitations$ = this.eventInvitationService.getGuests(eventInvitationId);
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
