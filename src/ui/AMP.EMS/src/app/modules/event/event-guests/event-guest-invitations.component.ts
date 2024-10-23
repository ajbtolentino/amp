import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { EventGuest } from '../../../core/models/event-guest';
import { EventService } from '../../../core/services/event.service';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';
import { Observable } from 'rxjs';
import { Event } from '../../../core/models/event';
import { EventInvitation } from '../../../core/models/event-invitation';

@Component({
  selector: 'app-event-guest-invitations',
  templateUrl: './event-guest-invitations.component.html',
  styles: ``
})
export class EventGuestInvitationComponent implements OnInit {
  eventId!: string;
  eventGuest$: Observable<EventGuest> = new Observable<EventGuest>();
  eventGuestInvitations: Observable<EventGuestInvitation> = new Observable<EventGuestInvitation>();
  eventInvitationId: Observable<EventInvitation> = new Observable<EventInvitation>();

  isCreating: boolean = false;

  selectedItems: EventGuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  templateCode!: string;

  constructor(private eventService: EventService,
    private eventGuestInvitationService: EventGuestInvitationService,
    private eventGuestService: EventGuestService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    @Inject(DOCUMENT) private document: Document) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';

    const eventGuestId = this.route.snapshot.paramMap.get('eventGuestId') || '';
    this.eventGuest$ = this.eventGuestService.get(eventGuestId);
  }
}
