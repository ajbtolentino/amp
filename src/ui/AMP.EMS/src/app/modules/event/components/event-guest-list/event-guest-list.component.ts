import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestRoleService, GuestService } from '@modules/event';
import { Guest, GuestRole, PagedResult, Role } from '@shared/models';
import { Table, TableLazyLoadEvent } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestListComponent implements OnInit {
  eventId!: string;

  guests$: Observable<PagedResult<Guest>> = new Observable<PagedResult<Guest>>();
  roles$: Observable<Role[]> = new Observable<Role[]>();

  selectedItems: Guest[] | null = [];

  @ViewChild('dt') table!: Table;

  searchKeyword?: string;

  constructor(private eventService: EventService,
    private guestRoleService: GuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.roles$ = this.eventService.getRoles(this.eventId);
  }

  refreshGrid = (event: TableLazyLoadEvent) => {
    this.guests$ = of<PagedResult<Guest>>({ result: [], totalRecords: 0, pageNumber: 0 })
    const pageNumber = event.first! / event.rows!;

    const search: any = event.filters && event.filters || {};
    const roleIds = search.role?.length && search.role[0].value?.map((_: any) => _) || [];
    this.searchKeyword = search.global?.value;

    this.guests$ = this.loadGuests(pageNumber, event.rows!, search.global?.value, event.sortField?.toString(), event.sortOrder == 1 ? 'Ascending' : 'Descending', roleIds);
  }

  loadGuests = (pageNumber: number, rows: number, filter?: string, sortField?: string, sortDirection?: 'Ascending' | 'Descending', roleIds?: string[]) => {
    return this.eventService.getGuests(this.eventId, pageNumber, rows, filter, sortField, sortDirection, roleIds).pipe(
      switchMap(eventGuests => this.loadGuestRole(eventGuests))
    );
  }

  loadGuestRole = (eventGuests: PagedResult<Guest>): Observable<PagedResult<Guest>> => {
    return this.guestRoleService.getByGuestIds(eventGuests.result!.filter(_ => _.id).map(_ => _.id!))
      .pipe(
        switchMap(eventGuestRoles => this.loadRole(eventGuestRoles)),
        map(eventGuestRoles => ({
          pageNumber: eventGuests.pageNumber,
          totalRecords: eventGuests.totalRecords,
          result: eventGuests.result!.map(eventGuest => {
            return {
              ...eventGuest,
              eventGuestRoles: eventGuestRoles.filter(_ => _.guestId === eventGuest.id)
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

    return this.lookupService.getByIds('role', guestRoles.filter(_ => _.roleId).map(_ => _.roleId!))
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

  hasResponded = (item: any) => {
    return item.eventGuestInvitations?.filter((_: any) => _.rsvps?.length ?? false).length ?? false;
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
                const pageNumber = this.table.first! / this.table.rows!;
                return this.loadGuests(pageNumber, this.table.rows!);
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
                const pageNumber = this.table.first! / this.table.rows!;
                return this.loadGuests(pageNumber, this.table.rows!);
              })
            )
        }
      });
    }
  }
}
