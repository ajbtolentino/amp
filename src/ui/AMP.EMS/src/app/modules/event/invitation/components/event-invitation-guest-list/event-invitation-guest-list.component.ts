import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, RsvpService } from '@core/services';
import { EventGuestInvitationService, GuestService } from '@modules/event/guest';
import { EventInvitationService } from '@modules/event/invitation';
import { EventGuest, EventGuestInvitation, EventGuestInvitationRsvp, EventInvitation } from '@shared/models';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { map, Observable, switchMap } from 'rxjs';

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

  selectedItems: EventGuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  templateCode!: string;

  constructor(
    private eventService: EventService,
    private guestService: GuestService,
    private eventGuestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService,
    private eventInvitationService: EventInvitationService,
    private messageService: MessageService,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    this.eventInvitationId = this.route.snapshot.paramMap.get('eventInvitationId') || '';
    this.eventInvitation$ = this.loadInvitation();
    this.eventGuests$ = this.loadEventGuests();
  }

  loadInvitation = (): Observable<EventInvitation> => {
    return this.eventInvitationService.get(this.eventInvitationId);
  }

  loadEventGuests = () => {
    return this.eventService.getGuests(this.eventId)
      .pipe(
        switchMap(eventGuests => this.loadEventGuestInvitations(eventGuests)),
        switchMap(eventGuests => this.loadGuest(eventGuests))
      );
  }

  loadEventGuestInvitations = (eventGuests: EventGuest[]): Observable<EventGuest[]> => {
    return this.eventGuestInvitationService.getByEventGuestIds(eventGuests.map(_ => _.id!))
      .pipe(
        switchMap(eventGuestInvitations => this.loadEventGuestInvitationRsvps(eventGuestInvitations)),
        map(eventGuestInvitations => {
          return eventGuests.map(eventGuest => ({
            ...eventGuest,
            eventGuestInvitations: eventGuestInvitations.filter(_ => _.eventGuestId === eventGuest.id)
          }))
        })
      );
  }

  loadEventGuestInvitationRsvps = (eventGuestInvitations: EventGuestInvitation[]): Observable<EventGuestInvitation[]> => {
    return this.rsvpService.getByEventGuestInvitationIds(eventGuestInvitations.map(_ => _.id!))
      .pipe(
        switchMap(eventGuestInvitationRsvps => this.loadEventGuestInvitationRsvpItems(eventGuestInvitationRsvps)),
        map(eventGuestInvitationRsvps => {
          return eventGuestInvitations.map(eventGuestInvitation => ({
            ...eventGuestInvitation,
            eventGuestInvitationRsvps: eventGuestInvitationRsvps.filter(_ => _.eventGuestInvitationId === eventGuestInvitation.id)
          }))
        })
      )
  }

  loadEventGuestInvitationRsvpItems = (eventGuestInvitationRsvps: EventGuestInvitationRsvp[]): Observable<EventGuestInvitationRsvp[]> => {
    return this.rsvpService.getItemsByIds(eventGuestInvitationRsvps.map(_ => _.id!))
      .pipe(
        map(eventGuestInvitationRsvpItems => {
          return eventGuestInvitationRsvps.map(eventGuestInvitationRsvp => ({
            ...eventGuestInvitationRsvp,
            eventGuestInvitationRsvpItems: eventGuestInvitationRsvpItems.filter(_ => _.eventGuestInvitationRsvpId === eventGuestInvitationRsvp.id)
          }))
        })
      )
  }

  loadGuest = (eventGuests: EventGuest[]): Observable<EventGuest[]> => {
    return this.guestService.getByIds(eventGuests.map(_ => _.guestId!))
      .pipe(
        map(guests => {
          return eventGuests.map(eventGuest => {
            return {
              ...eventGuest,
              guest: guests.find(_ => _.id === eventGuest.guestId)
            }
          })
        })
      );
  }

  add = async (eventGuestId: string) => {
    this.eventGuests$ = this.eventGuestInvitationService.add({
      eventGuestId: eventGuestId,
      eventInvitationId: this.eventInvitationId
    }).pipe(
      switchMap(() => this.loadEventGuests())
    );
  }

  delete = async (id: string) => {
    this.eventGuests$ = this.eventGuestInvitationService.delete(id)
      .pipe(
        switchMap(() => this.loadEventGuests())
      );
  }

  copyLink = (code: string) => {
    const url = `${location.protocol}//${location.host}/invitation/${code}`;
    navigator.clipboard.writeText(url);
    this.messageService.add({ severity: "info", summary: "Success", detail: "Link copied!" });
  }
}
