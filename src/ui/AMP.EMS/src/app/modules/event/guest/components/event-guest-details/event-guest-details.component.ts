import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { EventGuestRoleService, EventGuestService, GuestService } from '@modules/event/guest';
import { EventGuest, EventGuestRole, EventInvitation, EventInvitationInfo } from '@shared/models';
import { MessageService } from 'primeng/api';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html'
})
export class EventGuestDetailsComponent implements OnInit, OnDestroy {
  eventId!: string;
  eventGuestId: string | null | undefined;

  eventGuest$: Observable<EventGuest> = new Observable<EventGuest>();
  eventGuestInvitatins$: Observable<EventInvitationInfo[]> = new Observable<EventInvitationInfo[]>();

  eventRoles$: Observable<EventGuestRole[]> = new Observable<EventGuestRole[]>();
  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();

  selectedEventInvitationIds: string[] = [];
  selectedEventRoleIds: string[] = [];

  constructor(private eventService: EventService,
    private eventGuestService: EventGuestService,
    private eventGuestRoleService: EventGuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    this.eventGuestId = this.route.snapshot.paramMap.get('eventGuestId');
    this.eventGuest$ = of<EventGuest>({ eventId: this.eventId, guest: {}, seats: 1 });

    this.loadArray();

    if (this.eventGuestId)
      this.eventGuest$ = this.loadEventGuest();
  }

  loadEventGuest = (): Observable<EventGuest> => {
    return this.eventGuestService.get(this.eventGuestId || '').pipe(
      switchMap(eventGuest => this.loadGuest(eventGuest)),
      switchMap(eventGuest => this.loadEventGuestRoles(eventGuest)),
      map(response => {
        if (response.eventGuestRoles?.length) this.selectedEventRoleIds = response.eventGuestRoles?.filter(_ => _.role?.id).map(_ => _.role?.id!);
        if (response.eventGuestInvitations?.length) this.selectedEventInvitationIds = response.eventGuestInvitations?.filter(_ => _.eventInvitationId).map(_ => _.eventInvitationId!);
        return response;
      }));
  }

  loadGuest = (eventGuest: EventGuest): Observable<EventGuest> => {
    return this.guestService.get(eventGuest.guestId!).pipe(map(guest => {
      return {
        ...eventGuest,
        guest: guest
      }
    }));
  }

  loadEventGuestRoles = (eventGuest: EventGuest): Observable<EventGuest> => {
    return this.eventGuestRoleService.getByEventGuestIds([eventGuest.id!])
      .pipe(
        switchMap(eventGuestRoles => this.loadRoles(eventGuestRoles)),
        map(eventGuestRoles => (
          {
            ...eventGuest,
            eventGuestRoles: eventGuestRoles
          }
        ))
      );
  }

  loadRoles = (eventGuestRoles: EventGuestRole[]): Observable<EventGuestRole[]> => {
    if (!eventGuestRoles.length) return of<EventGuestRole[]>([]);

    return this.lookupService.getByIds('role', eventGuestRoles.filter(_ => _.roleId).map(_ => _.roleId!))
      .pipe(
        map(roles => eventGuestRoles.map(eventGuestRole => ({
          ...eventGuestRole,
          role: roles.find(_ => _.id === eventGuestRole.roleId)
        }))
        )
      );
  }

  loadArray = () => {
    this.eventRoles$ = this.eventService.getRoles(this.eventId);
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
  }

  save = async (item: EventGuest) => {
    if (item?.guest?.firstName?.trim() && item?.guest?.lastName?.trim())
      if (item.id) {
        this.eventGuest$ = this.eventGuestService.update(item, this.selectedEventRoleIds, this.selectedEventInvitationIds).pipe(
          switchMap(() => this.loadEventGuest()));
      }
      else {
        this.eventGuest$ = this.eventGuestService.add(item, this.selectedEventRoleIds, this.selectedEventInvitationIds).pipe(map(eventGuest => {
          this.redirect(eventGuest);
          return eventGuest;
        }));
      }
  }

  redirect = (item: any) => {
    this.router.navigate([`/event/${this.eventId}/guests/${item.id}/edit`]);
  }

  copyLink = (code: string) => {
    navigator.clipboard.writeText(code);
    this.messageService.add({ severity: "info", summary: "Success", detail: "Link copied!" });
  }

  ngOnDestroy(): void {

  }
}

