import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventGuestInvitationService, EventGuestService } from '@modules/event/guest';
import { Guest, EventGuestInvitation, EventInvitation, EventGuest } from '@shared/models';
import { Table } from 'primeng/table';
import { lastValueFrom, map, Observable } from 'rxjs';
import { EventInvitationService } from '@modules/event/invitation';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-event-invitation-guest-list',
  templateUrl: './event-invitation-guest-list.component.html',
  styles: `
  .invitation-badge {
    border-radius: var(--border-radius);
    padding: .25em .5rem;
    text-transform: uppercase;
    font-weight: 700;
    font-size: 12px;
    letter-spacing: .3px;

    &.status-not-assigned {
        background: #FEEDAF;
        color: #8A5340;
    }

    &.status-awaiting-response {
        background: #B3E5FC;
        color: #23547B;
    }

    &.status-responded {
        background: #C8E6C9;
        color: #256029;
    }

    &.status-ACCEPT {
        background: #C8E6C9 !important;
        color: #256029 !important;
    }

    &.status-DECLINE {
        background: #FFCDD2;
        color: #C63737;
    }
}
  `
})
export class EventInvitationGuestListComponent implements OnInit {
  eventId!: string;
  eventInvitationId!: string;

  eventInvitation$: Observable<EventInvitation> = new Observable<EventInvitation>();
  eventGuests$: Observable<EventGuest[]> = new Observable<EventGuest[]>();
  eventGuestInvitations: Observable<EventGuestInvitation> = new Observable<EventGuestInvitation>();


  isCreating: boolean = false;

  selectedItems: EventGuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  templateCode!: string;

  constructor(
    private eventGuestInvitationService: EventGuestInvitationService,
    private eventInvitationService: EventInvitationService,
    private eventGuestService: EventGuestService,
    private messageService: MessageService,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    const eventInvitationId = this.route.snapshot.paramMap.get('eventInvitationId') || '';

    this.eventInvitation$ = this.eventInvitationService.get(eventInvitationId);
    this.eventGuests$ = this.eventGuestService.getAll();
  }

  add = async (eventGuestId: string, eventInvitationId: string) => {
    const response = await lastValueFrom(this.eventGuestInvitationService.add({
      eventGuestId: eventGuestId,
      eventInvitationId: eventInvitationId
    }));

    this.eventGuests$ = this.eventGuestService.getAll();
  }

  delete = async (id: string) => {
    await lastValueFrom(this.eventGuestInvitationService.delete(id));

    this.eventGuests$ = this.eventGuestService.getAll();
  }

  getEventGuestInvitation = (eventGuest: EventGuest, eventInvitationId: string) => {
    return eventGuest.eventGuestInvitations?.filter(_ => _.eventInvitationId === eventInvitationId)[0] || {};
  }

  copyLink = (code: string) => {
    const url = `${location.protocol}//${location.host}/invitation/${code}`;
    navigator.clipboard.writeText(url);
    this.messageService.add({ severity: "info", summary: "Success", detail: "Link copied!" });
  }
}
