import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventGuestRole } from '../../../core/models/event-guest-role';
import { EventService } from '../../../core/services/event.service';
import { EventInvitation } from '../../../core/models/event-invitation';
import { firstValueFrom, from, map, Observable, of, Subject, switchMap, tap } from 'rxjs';
import { GuestService } from '../../../core/services/guest.service';
import { Guest } from '../../../core/models/guest';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventGuest } from '../../../core/models/event-guest';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html',
  styles: ``
})
export class EventGuestDetailsComponent implements OnInit, OnDestroy {
  eventId!: string;

  eventGuest$: Observable<{ guest: Guest, eventGuest: EventGuest }> = new Observable<{ guest: Guest, eventGuest: EventGuest }>();
  eventRoles$: Observable<EventGuestRole[]> = new Observable<EventGuestRole[]>();
  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();
  submitEventGuest$: Subject<{ eventGuest: Guest, invitationIds: string[], roleIds: string[] }> = new Subject<{ eventGuest: Guest, invitationIds: string[], roleIds: string[] }>();

  selectedEventRoles: string[] = [];
  selectedEventInvitations: string[] = [];

  constructor(private eventService: EventService,
    private eventGuestService: EventGuestService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    this.loadArray();
    this.loadEventGuest();
  }

  loadEventGuest = () => {
    const eventGuestId = this.route.snapshot.paramMap.get('eventGuestId');

    if (eventGuestId) {
      this.eventGuest$ = this.eventGuestService.get(eventGuestId || '').pipe(map(response => {
        this.selectedEventInvitations = response.eventGuest.eventInvitations?.map(_ => _ || '').filter(_ => _) || [];
        this.selectedEventRoles = response.eventGuest.eventGuestRoles?.filter(_ => _) || [];
        return response;
      }));
    }
    else {
      this.eventGuest$ = of<{ eventGuest: EventGuest, guest: Guest }>({ eventGuest: { eventId: this.eventId }, guest: {} });
    }
  }

  loadArray = () => {
    this.eventRoles$ = this.eventService.getRoles(this.eventId);
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
  }

  save = (item: { guest: Guest, eventGuest: EventGuest }) => {
    if (item?.guest?.firstName?.trim() && item?.guest?.lastName?.trim())
      if (item.eventGuest.id)
        firstValueFrom(this.eventGuestService.update(item.eventGuest, item.guest)).then(() => this.redirect());
      else
        firstValueFrom(this.eventGuestService.add(item.eventGuest, item.guest)).then(() => this.redirect());
  }

  redirect = () => {
    this.router.navigate([`/event/${this.eventId}/guests`]);
  }

  ngOnDestroy(): void {

  }
}

