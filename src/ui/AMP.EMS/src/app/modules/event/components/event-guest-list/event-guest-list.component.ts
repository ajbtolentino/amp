import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestRoleService, GuestService } from '@modules/event';
import { Guest, GuestRole, PagedResult, Role } from '@shared/models';
import { Table, TableLazyLoadEvent } from 'primeng/table';
import { map, Observable, of, shareReplay, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestListComponent implements OnInit {
  eventId!: string;

  attendeeModal: boolean = false;
  guest$: Observable<Guest> = new Observable<Guest>();
  selectedInvitationIds: string[] = [];
  selectedRoleIds: string[] = [];

  guests$: Observable<PagedResult<Guest>> = new Observable<PagedResult<Guest>>();
  roles$: Observable<Role[]> = new Observable<Role[]>();

  selectedItems: Guest[] | null = [];

  @ViewChild('dt') table!: Table;

  salutations: string[] = [
    "Atty.",
    "Mayor",
    "Judge",
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

  searchKeyword?: string;

  constructor(private eventService: EventService,
    private guestRoleService: GuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private confirmationService: ConfirmationService,
    private eventGuestRoleService: GuestRoleService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.roles$ = this.eventService.getRoles(this.eventId).pipe(shareReplay());
  }

  refreshGrid = (event: TableLazyLoadEvent) => {
    this.guests$ = of<PagedResult<Guest>>({ result: [], totalRecords: 0, pageNumber: 0 })


    this.guests$ = this.loadGuests(event);
  }

  loadGuests = (event: TableLazyLoadEvent) => {
    const pageNumber = event.first! / event.rows!;

    const search: any = event.filters && event.filters || {};
    const roleIds = search.role?.length && search.role[0].value?.map((_: any) => _) || [];
    this.searchKeyword = search.global?.value;

    return this.eventService.getGuests(this.eventId, pageNumber, event.rows!, search.global?.value, event.sortField?.toString(), event.sortOrder == 1 ? 'Ascending' : 'Descending', roleIds).pipe(
      switchMap(eventGuests => this.loadGuestRole(eventGuests))
    );
  }

  loadGuestRole = (eventGuests: PagedResult<Guest>): Observable<PagedResult<Guest>> => {
    return this.guestRoleService.getByGuestIds(eventGuests.result!.filter(_ => _.id).map(_ => _.id!))
      .pipe(
        switchMap(guestRoles => this.loadRole(guestRoles)),
        map(guestRoles => ({
          pageNumber: eventGuests.pageNumber,
          totalRecords: eventGuests.totalRecords,
          result: eventGuests.result!.map(eventGuest => {
            return {
              ...eventGuest,
              guestRoles: guestRoles.sort((a, b) => a.role!.name! > b.role!.name! ? 1 : -1).filter(_ => _.guestId === eventGuest.id)
            }
          })
        })
        )
      ) || of<PagedResult<Guest>>({ result: [] });
  }

  onSearch = (event: any) => {
    this.table.filterGlobal(event.target!.value, 'contains');
  }

  loadRole = (guestRoles: GuestRole[]): Observable<GuestRole[]> => {
    if (!guestRoles.length) return of<GuestRole[]>(guestRoles);

    return this.roles$
      .pipe(
        map(roles => {
          return guestRoles.map(guestRole => {
            return {
              ...guestRole,
              role: roles.find(_ => _.id === guestRole.roleId)
            }
          })
        }));
  }

  loadGuestRoles = (attendee: Guest): Observable<Guest> => {
    return this.eventGuestRoleService.getByGuestIds([attendee.id!])
      .pipe(
        map(guestRoles => (
          {
            ...attendee,
            guestRoles: guestRoles
          }
        )),
        tap((_) => {
          if (attendee.guestRoles) this.selectedRoleIds = _.guestRoles.map(_ => _.roleId!)
        })
      );
  }

  loadRoles = (guestRoles: GuestRole[]): Observable<GuestRole[]> => {
    if (!guestRoles.length) return of<GuestRole[]>([]);

    return this.roles$
      .pipe(
        map(roles => guestRoles.map(guestRole => ({
          ...guestRole,
          role: roles.find(_ => _.id === guestRole.roleId)
        })),
          tap((roles) => console.log(roles))
        )
      );
  }

  clear = () => {
    this.table.clear();
    this.table.clearState();
  }

  hasResponded = (item: any) => {
    return item.eventGuestInvitations?.filter((_: any) => _.rsvps?.length ?? false).length ?? false;
  }

  showAttendeeModal = (attendee?: Guest) => {
    if (!attendee) this.guest$ = of<Guest>({ eventId: this.eventId });
    else this.guest$ = this.guestService.get(attendee.id!)
      .pipe(
        switchMap(attendee => this.loadGuestRoles(attendee))
      );

    this.attendeeModal = true;
    this.selectedRoleIds = [];
  }

  saveAttendee = async (item: Guest) => {
    if (item?.firstName?.trim() && item?.lastName?.trim())
      if (item.id) {
        this.guests$ = this.guestService.update(item, this.selectedRoleIds, this.selectedInvitationIds)
          .pipe(
            switchMap(() => this.loadGuests(this.table.createLazyLoadMetadata()))
          );
      }
      else {
        this.guests$ = this.guestService.add(item, this.selectedRoleIds, this.selectedInvitationIds)
          .pipe(
            switchMap(() => this.loadGuests(this.table.createLazyLoadMetadata()))
          );
      }

    this.attendeeModal = false;
  }

  delete = (guest: Guest) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${guest.guest?.firstName} ${guest.guest?.lastName}? 
                All associated records will also be deleted.`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (guest.id) {
          this.guests$ = this.guestService.delete(guest.id)
            .pipe(
              switchMap(() => {
                return this.loadGuests(this.table.createLazyLoadMetadata());
              })
            )
        }
      }
    });
  }

  deleteSelectedItems = () => {
    if (this.selectedItems?.filter(_ => _.id).length) {
      this.confirmationService.confirm({
        message: `Are you sure you want to delete the selected guests? 
                All associated records will also be deleted.`,
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.guests$ = this.guestService.deleteSelected(this.selectedItems?.map(_ => _.id!)!)
            .pipe(
              switchMap(() => {
                return this.loadGuests(this.table.createLazyLoadMetadata());
              })
            )
        }
      });
    }
  }
}
