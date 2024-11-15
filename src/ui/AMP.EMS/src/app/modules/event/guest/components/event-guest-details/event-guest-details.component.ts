import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestInvitationService, GuestRoleService, GuestService } from '@modules/event/guest';
import { EventInvitationInfo, Guest, GuestRole, Invitation } from '@shared/models';
import { MessageService } from 'primeng/api';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html'
})
export class EventGuestDetailsComponent implements OnInit, OnDestroy {
  eventId!: string;
  eventGuestId: string | null | undefined;

  guest$: Observable<Guest> = new Observable<Guest>();
  eventGuestInvitatins$: Observable<EventInvitationInfo[]> = new Observable<EventInvitationInfo[]>();

  eventRoles$: Observable<GuestRole[]> = new Observable<GuestRole[]>();
  eventInvitations$: Observable<Invitation[]> = new Observable<Invitation[]>();

  selectedEventInvitationIds: string[] = [];
  selectedEventRoleIds: string[] = [];

  constructor(private eventService: EventService,
    private eventGuestInvitationService: GuestInvitationService,
    private eventGuestRoleService: GuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    this.eventGuestId = this.route.snapshot.paramMap.get('eventGuestId');
    this.guest$ = of<Guest>({ eventId: this.eventId, seats: 1 });

    this.loadArray();

    if (this.eventGuestId)
      this.guest$ = this.loadEventGuest();
  }

  loadEventGuest = (): Observable<Guest> => {
    return this.guestService.get(this.eventGuestId || '').pipe(
      switchMap(eventGuest => this.loadGuestRoles(eventGuest)),
      switchMap(eventGuest => this.loadGuestInvitations(eventGuest)),
      map(response => {
        if (response.eventGuestRoles?.length) this.selectedEventRoleIds = response.eventGuestRoles?.filter(_ => _.role?.id).map(_ => _.role?.id!);
        if (response.eventGuestInvitations?.length) this.selectedEventInvitationIds = response.eventGuestInvitations?.filter(_ => _.invitationId).map(_ => _.invitationId!);
        return response;
      }));
  }

  loadGuest = (eventGuest: Guest): Observable<Guest> => {
    return this.guestService.get(eventGuest.guestId!).pipe(map(guest => {
      return {
        ...eventGuest,
        guest: guest
      }
    }));
  }

  loadGuestInvitations = (eventGuest: Guest): Observable<Guest> => {
    return this.eventGuestInvitationService.getByGuestIds([eventGuest.id!])
      .pipe(map(eventGuestInvitations => ({
        ...eventGuest,
        eventGuestInvitations: eventGuestInvitations
      })));
  }

  loadGuestRoles = (guest: Guest): Observable<Guest> => {
    return this.eventGuestRoleService.getByGuestIds([guest.id!])
      .pipe(
        switchMap(eventGuestRoles => this.loadRoles(eventGuestRoles)),
        map(eventGuestRoles => (
          {
            ...guest,
            eventGuestRoles: eventGuestRoles
          }
        ))
      );
  }

  loadRoles = (eventGuestRoles: GuestRole[]): Observable<GuestRole[]> => {
    if (!eventGuestRoles.length) return of<GuestRole[]>([]);

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

  save = async (item: Guest) => {
    if (item?.firstName?.trim() && item?.lastName?.trim())
      if (item.id) {
        this.guest$ = this.guestService.update(item, this.selectedEventRoleIds, this.selectedEventInvitationIds).pipe(
          switchMap(() => this.loadEventGuest()));
      }
      else {
        this.guest$ = this.guestService.add(item, this.selectedEventRoleIds, this.selectedEventInvitationIds).pipe(map(eventGuest => {
          this.redirect(eventGuest);
          return eventGuest;
        }));
      }
  }

  redirect = (item: any) => {
    this.router.navigate(['events', this.eventId, `guests`, `${item.id}`, `edit`]);
  }

  copyLink = (code: string) => {
    navigator.clipboard.writeText(code);
    this.messageService.add({ severity: "info", summary: "Success", detail: "Link copied!" });
  }

  ngOnDestroy(): void {

  }
}

