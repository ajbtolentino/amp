import { Component, OnDestroy, OnInit } from '@angular/core';
import { EventGuest } from '../../../core/models/event-guest';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventRoleService } from '../../../core/services/event-role.service';
import { EventRole } from '../../../core/models/event-role';
import { EventService } from '../../../core/services/event.service';
import { EventInvitationService } from '../../../core/services/event-invitation.service';
import { EventInvitation } from '../../../core/models/event-invitation';
import { firstValueFrom, from, map, Observable, of, Subject, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html',
  styles: ``
})
export class EventGuestDetailsComponent implements OnInit, OnDestroy {
  eventId!: string;

  eventGuest$: Observable<EventGuest> = new Observable<EventGuest>();
  eventRoles$: Observable<EventRole[]> = new Observable<EventRole[]>();
  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();
  submitEventGuest$: Subject<{ eventGuest: EventGuest, invitationIds: string[], roleIds: string[] }> = new Subject<{ eventGuest: EventGuest, invitationIds: string[], roleIds: string[] }>();

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
      this.eventGuest$ = this.eventGuestService.get(eventGuestId || '').pipe(map(eventGuest => {
        this.selectedEventInvitations = eventGuest.eventGuestInvitations?.map(_ => _.eventInvitationId || '').filter(_ => _) || [];
        this.selectedEventRoles = eventGuest.eventGuestRoles?.map(_ => _.eventRoleId || '').filter(_ => _) || [];
        return eventGuest;
      }));
    }
    else {
      this.eventGuest$ = of<EventGuest>({ eventId: this.eventId, guest: {} });
    }
  }

  loadArray = () => {
    this.eventRoles$ = this.eventService.getRoles(this.eventId);
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
  }

  save = (eventGuest: EventGuest) => {
    if (eventGuest.guest?.firstName?.trim() && eventGuest.guest?.lastName?.trim())
      if (eventGuest.guestId)
        firstValueFrom(this.eventGuestService.update(eventGuest, this.selectedEventRoles, this.selectedEventInvitations)).then(() => this.redirect());
      else
        firstValueFrom(this.eventGuestService.add(eventGuest, this.selectedEventRoles, this.selectedEventInvitations)).then(() => this.redirect());
  }

  redirect = () => {
    this.router.navigate([`/event/${this.eventId}/guests`]);
  }

  ngOnDestroy(): void {

  }
}

