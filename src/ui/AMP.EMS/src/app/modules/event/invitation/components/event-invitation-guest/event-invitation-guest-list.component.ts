import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guest, EventGuestInvitation, EventInvitation } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-event-invitation-guest-list',
  templateUrl: './event-invitation-guest-list.component.html',
  styles: ``
})
export class EventInvitationGuestListComponent implements OnInit {
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

  constructor(
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    @Inject(DOCUMENT) private document: Document) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';

    const guestId = this.route.snapshot.paramMap.get('guestId') || '';
  }
}
