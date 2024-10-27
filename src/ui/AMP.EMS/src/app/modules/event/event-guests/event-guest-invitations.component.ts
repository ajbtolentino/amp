import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { EventService } from '../../../core/services/event.service';
import { Observable } from 'rxjs';
import { Event } from '../../../core/models/event';
import { EventInvitation } from '../../../core/models/event-invitation';
import { GuestService } from '../../../core/services/guest.service';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { Guest } from '../../../core/models/guest';

@Component({
  selector: 'app-event-guest-invitations',
  templateUrl: './event-guest-invitations.component.html',
  styles: ``
})
export class EventGuestInvitationComponent implements OnInit {
  eventId!: string;
  guest$: Observable<Guest> = new Observable<Guest>();
  eventGuestInvitations: Observable<EventGuestInvitation> = new Observable<EventGuestInvitation>();
  eventInvitationId: Observable<EventInvitation> = new Observable<EventInvitation>();

  isCreating: boolean = false;

  selectedItems: EventGuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  templateCode!: string;

  constructor(private eventService: EventService,
    private guestService: GuestService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    @Inject(DOCUMENT) private document: Document) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';

    const guestId = this.route.snapshot.paramMap.get('guestId') || '';
    this.guest$ = this.guestService.get(guestId);
  }
}
