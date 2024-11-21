import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestRoleService, GuestService } from '@modules/event';
import { Guest, GuestRole, PagedResult } from '@shared/models';
import { Table } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestListComponent implements OnInit {
  eventId!: string;

  guests$: Observable<PagedResult<Guest>> = new Observable<PagedResult<Guest>>();

  selectedItems: Guest[] | null = [];

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private guestRoleService: GuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
  }

  refreshGrid = (event: any) => {
    this.guests$ = of<PagedResult<Guest>>({ result: [], totalRecords: 0, pageNumber: 0 })
    const pageNumber = event.first / event.rows;

    console.log(event);

    this.guests$ = this.loadGuests(pageNumber, event.rows);
  }

  loadGuests = (pageNumber: number, rows: number) => {
    return this.eventService.getGuests(this.eventId, pageNumber, rows).pipe(
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
