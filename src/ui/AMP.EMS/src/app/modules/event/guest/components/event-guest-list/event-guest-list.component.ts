import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { EventGuestRoleService, EventGuestService, GuestService } from '@modules/event/guest';
import { EventGuest, EventGuestRole, Guest } from '@shared/models';
import { lastValueFrom, map, Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestListComponent implements OnInit {
  eventId!: string;

  eventGuests$: Observable<EventGuest[]> = new Observable<EventGuest[]>();

  selectedItems: Guest[] | null = [];

  constructor(private eventService: EventService,
    private eventGuestService: EventGuestService,
    private eventGuestRoleService: EventGuestRoleService,
    private guestService: GuestService,
    private lookupService: LookupService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.refreshGrid();
  }

  refreshGrid = () => {
    this.eventGuests$ = this.eventService.getGuests(this.eventId).pipe(
      switchMap(eventGuests => this.loadGuest(eventGuests)),
      tap(eventGuests => console.log(eventGuests)),
      switchMap(eventGuests => this.loadEventGuestRole(eventGuests))
    );
  }

  loadGuest = (eventGuests: EventGuest[]): Observable<EventGuest[]> => {
    return this.guestService.getByIds(eventGuests.filter(_ => _.guestId).map(_ => _.guestId!)
    ).pipe(
      map(guests => {
        return eventGuests.map(eventGuest => {
          return {
            ...eventGuest,
            guest: guests.find(_ => _.id === eventGuest.guestId)
          }
        });
      }
      ));
  }

  loadEventGuestRole = (eventGuests: EventGuest[]): Observable<EventGuest[]> => {
    return this.eventGuestRoleService.getByEventGuestIds(eventGuests.filter(_ => _.id).map(_ => _.id!))
      .pipe(
        switchMap(eventGuestRoles => this.loadRole(eventGuestRoles)),
        map(eventGuestRoles => {
          return eventGuests.map(eventGuest => {
            return {
              ...eventGuest,
              eventGuestRoles: eventGuestRoles.filter(_ => _.eventGuestId === eventGuest.id)
            }
          })
        }));
  }

  loadRole = (eventGuestRoles: EventGuestRole[]): Observable<EventGuestRole[]> => {
    if (!eventGuestRoles.length) return of<EventGuestRole[]>(eventGuestRoles);

    return this.lookupService.getByIds('role', eventGuestRoles.filter(_ => _.roleId).map(_ => _.roleId!))
      .pipe(
        map(roles => {
          return eventGuestRoles.map(eventGuestRole => {
            return {
              ...eventGuestRole,
              role: roles.find(_ => _.id === eventGuestRole.roleId)
            }
          })
        }));
  }

  hasResponded = (item: any) => {
    return item.eventGuestInvitations?.filter((_: any) => _.rsvps?.length ?? false).length ?? false;
  }

  delete = (eventGuest: EventGuest) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${eventGuest.guest?.firstName} ${eventGuest.guest?.lastName}?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (eventGuest.id) {
          await lastValueFrom(this.eventGuestService.delete(eventGuest.id));

          this.refreshGrid();
        }
      }
    });
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.eventGuests$ = this.eventGuestService.deleteSelected(this.selectedItems!.map(_ => _.id!)).pipe(switchMap(() => this.eventService.getGuests(this.eventId)));
      }
    });
  }
}
