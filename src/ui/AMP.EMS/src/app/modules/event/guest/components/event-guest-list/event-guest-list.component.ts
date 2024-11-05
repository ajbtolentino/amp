import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

import { EventService } from '@core/services/event.service';
import { EventGuestService } from '@modules/services/event-guest.service';
import { EventGuest } from '@shared/models';
import { Guest } from '@shared/models/guest-model';
import { lastValueFrom, Observable, switchMap } from 'rxjs';

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
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
      }
    });
  }

  refreshGrid = () => {
    this.eventGuests$ = this.eventService.getGuests(this.eventId);
  }

  hasResponded = (item: any) => {
    return item.eventGuestInvitations?.filter((_: any) => _.rsvps?.length ?? false).length ?? false;
  }

  delete = (eventGuest: EventGuest) => {
    console.log(eventGuest);
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
