import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

import { firstValueFrom, lastValueFrom, Observable, take } from 'rxjs';
import { Guest } from '@shared/models/guest-model';
import { EventService } from '@core/services/event.service';
import { EventGuestService } from '@modules/services/event-guest.service';
import { EventGuest } from '@shared/models';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestListComponent implements OnInit {
  eventId!: string;

  guests$: Observable<Guest[]> = new Observable<Guest[]>();

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
    this.guests$ = this.eventService.getGuests(this.eventId);
  }

  hasResponded = (item: any) => {
    return item.eventGuestInvitations?.filter((_: any) => _.rsvps?.length ?? false).length ?? false;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        // this.eventGuests$ = this.eventGuests$.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;

        this.refreshGrid();
      }
    });
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
}
