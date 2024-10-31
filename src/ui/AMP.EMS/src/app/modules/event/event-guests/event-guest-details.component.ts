import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventGuestRole } from '../../../core/models/event-guest-role';
import { EventService } from '../../../core/services/event.service';
import { EventInvitation } from '../../../core/models/event-invitation';
import { firstValueFrom, from, lastValueFrom, map, Observable, of, Subject, switchMap, tap } from 'rxjs';
import { GuestService } from '../../../core/services/guest.service';
import { Guest } from '../../../core/models/guest';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventGuest } from '../../../core/models/event-guest';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { EventGuestInvitationResponse, EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';
import { EventGuestInvitationInfo, EventInvitationInfo } from '../../../core/models/event-invitation-info';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html',
  styleUrl: `./event-guest-list.component.scss`
})
export class EventGuestDetailsComponent implements OnInit, OnDestroy {
  eventId!: string;

  eventGuest$: Observable<EventGuest> = new Observable<EventGuest>();
  eventGuestInvitations$: Observable<EventInvitationInfo[]> = new Observable<EventInvitationInfo[]>();

  eventRoles$: Observable<EventGuestRole[]> = new Observable<EventGuestRole[]>();
  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();

  selectedEventInvitationIds: string[] = [];
  selectedEventRoleIds: string[] = [];

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
        if (response.eventGuestRoles?.length) this.selectedEventRoleIds = response.eventGuestRoles?.filter(_ => _.eventRoleId).map(_ => _.eventRoleId!);
        if (response.eventGuestInvitations?.length) this.selectedEventInvitationIds = response.eventGuestInvitations?.filter(_ => _.eventInvitationId).map(_ => _.eventInvitationId!);
        return response;
      }));
      this.eventGuestInvitations$ = this.eventGuestService.getInvitations(eventGuestId);
    }
    else {
      this.eventGuest$ = of<{ eventGuest: EventGuest, guest: Guest }>({ eventGuest: { eventId: this.eventId }, guest: {} });
    }
  }

  loadArray = () => {
    this.eventRoles$ = this.eventService.getRoles(this.eventId);
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
  }

  save = async (item: EventGuest) => {
    if (item?.guest?.firstName?.trim() && item?.guest?.lastName?.trim())
      if (item.id) {
        await lastValueFrom(this.eventGuestService.update(item, this.selectedEventRoleIds, this.selectedEventInvitationIds));
        this.loadEventGuest();
      }
      else {
        const response = await lastValueFrom(this.eventGuestService.add(item, this.selectedEventRoleIds, this.selectedEventInvitationIds));
        this.redirect(response);

      }
  }

  redirect = (item: any) => {
    this.router.navigate([`/event/${this.eventId}/guest/${item.id}`]);
  }

  ngOnDestroy(): void {

  }
}

