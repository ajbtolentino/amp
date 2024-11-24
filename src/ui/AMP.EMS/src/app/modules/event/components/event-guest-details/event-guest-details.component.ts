import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestInvitationService, GuestRoleService, GuestService } from '@modules/event';
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

  roles$: Observable<GuestRole[]> = new Observable<GuestRole[]>();
  invitations$: Observable<Invitation[]> = new Observable<Invitation[]>();

  selectedInvitationIds: string[] = [];
  selectedRoleIds: string[] = [];

  salutations: string[] = [
    "Mr.",
    "Mrs.",
    "Miss",
    "Ms.",
    "Dr.",
    "Prof.",
    "Rev.",
    "Hon.",
    "Sir",
    "Madam",
    "Engr."];

  suffixes: string[] = [
    "Jr.",
    "Sr.",
    "I",
    "II",
    "III",
    "IV",
  ]

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
    this.guest$ = of<Guest>({ eventId: this.eventId });

    this.loadArray();

    if (this.eventGuestId)
      this.guest$ = this.loadEventGuest();
  }

  loadEventGuest = (): Observable<Guest> => {
    return this.guestService.get(this.eventGuestId || '').pipe(
      switchMap(guest => this.loadGuestRoles(guest)),
      switchMap(guest => this.loadGuestInvitations(guest)),
      map(response => {
        if (response.guestRoles?.length) this.selectedRoleIds = response.guestRoles?.filter(_ => _.role?.id).map(_ => _.role?.id!);
        if (response.guestInvitations?.length) this.selectedInvitationIds = response.guestInvitations?.filter(_ => _.invitationId).map(_ => _.invitationId!);
        return response;
      }));
  }

  loadGuest = (guest: Guest): Observable<Guest> => {
    return this.guestService.get(guest.guestId!).pipe(map(guest => {
      return {
        ...guest,
        guest: guest
      }
    }));
  }

  loadGuestInvitations = (eventGuest: Guest): Observable<Guest> => {
    return this.eventGuestInvitationService.getByGuestIds([eventGuest.id!])
      .pipe(map(guestInvitations => ({
        ...eventGuest,
        guestInvitations: guestInvitations
      })));
  }

  loadGuestRoles = (guest: Guest): Observable<Guest> => {
    return this.eventGuestRoleService.getByGuestIds([guest.id!])
      .pipe(
        switchMap(guestRoles => this.loadRoles(guestRoles)),
        map(guestRoles => (
          {
            ...guest,
            guestRoles: guestRoles
          }
        ))
      );
  }

  loadRoles = (guestRoles: GuestRole[]): Observable<GuestRole[]> => {
    if (!guestRoles.length) return of<GuestRole[]>([]);

    return this.lookupService.getByIds('role', guestRoles.filter(_ => _.roleId).map(_ => _.roleId!))
      .pipe(
        map(roles => guestRoles.map(guestRole => ({
          ...guestRole,
          role: roles.find(_ => _.id === guestRole.roleId)
        }))
        )
      );
  }

  loadArray = () => {
    this.roles$ = this.eventService.getRoles(this.eventId);
    this.invitations$ = this.eventService.getInvitations(this.eventId);
  }

  save = async (item: Guest) => {
    if (item?.firstName?.trim() && item?.lastName?.trim())
      if (item.id) {
        this.guest$ = this.guestService.update(item, this.selectedRoleIds, this.selectedInvitationIds).pipe(
          switchMap(() => this.loadEventGuest()));
      }
      else {
        this.guest$ = this.guestService.add(item, this.selectedRoleIds, this.selectedInvitationIds).pipe(map(eventGuest => {
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

