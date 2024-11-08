import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventInvitationService } from '@modules/event/invitation';
import { CodeEditorComponent, CodeModel } from '@ngstack/code-editor';
import { EventInvitation } from '@shared/models';
import { Observable, of, tap } from 'rxjs';

@Component({
  selector: 'app-event-invitation-details',
  templateUrl: './event-invitation-details.component.html',
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
export class EventInvitationDetailsComponent implements OnInit {
  eventInvitationId: string | null | undefined;
  eventInvitation$: Observable<EventInvitation> = new Observable<EventInvitation>();

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

  currentDate: Date = new Date();

  @ViewChild('codeEditor', { static: false }) codeEditor!: CodeEditorComponent;

  constructor(private eventInvitationService: EventInvitationService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.parent?.parent?.snapshot.paramMap.get("eventId") || '';
    this.eventInvitationId = this.route.snapshot.paramMap.get("eventInvitationId") || '';
    this.loadEventInvitation()
  }

  loadEventInvitation = () => {
    this.eventInvitation$ = of<EventInvitation>({ eventId: this.eventId });

    if (this.eventInvitationId) {
      this.eventInvitation$ = this.eventInvitationService.get(this.eventInvitationId).pipe(tap(eventInvitation => {
        this.model.value = eventInvitation.html || '';
        if (eventInvitation.rsvpDeadline) eventInvitation.rsvpDeadline = new Date(eventInvitation.rsvpDeadline);
      }));
    }
  }

  onValueChanged(e: any, eventInvitation: EventInvitation) {
    eventInvitation.html = e;
  }

  save = (eventInvitation: EventInvitation) => {
    if (eventInvitation?.name?.trim()) {
      if (eventInvitation.id) {
        this.eventInvitation$ = this.eventInvitationService.update(eventInvitation).pipe(tap(() => this.loadEventInvitation()));
      }
      else {
        this.eventInvitation$ = this.eventInvitationService.add(eventInvitation).pipe(tap((eventInvitation) => this.redirect(eventInvitation)));
      }
    }
  }

  redirect = (item: any) => {
    this.router.navigate([`/event/${this.eventId}/invitations/${item.id}/edit`]);
  }

  onRsvpSubmit = () => {
    alert('Response Submitted!');
  }
}
