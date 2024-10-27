import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

import { Table } from 'primeng/table';
import { EventService } from '../../../core/services/event.service';
import { firstValueFrom, Observable, take } from 'rxjs';
import { Guest } from '../../../core/models/guest';
import { GuestService } from '../../../core/services/guest.service';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guest-list.component.html',
  styleUrl: './event-guest-list.component.scss',
})
export class EventGuestsComponent implements OnInit {
  eventId!: string;

  guests$: Observable<Guest[]> = new Observable<Guest[]>();

  selectedItems: Guest[] | null = [];

  isCreating: boolean = false;

  loading: boolean = true;

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private guestService: GuestService,
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

  refreshGrid = async () => {
    this.loading = true;

    this.guests$ = this.eventService.getGuests(this.eventId);

    this.loading = false;
    this.isCreating = false;
  }

  hasResponded = (item: Guest) => {
    return false;
  }

  getGuestDetails = (guestId: string): Observable<Guest> => {
    return this.guestService.get(guestId).pipe(take(1));
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.loading = true;

        // this.eventGuests$ = this.eventGuests$.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;

        this.loading = false;

        this.refreshGrid();
      }
    });
  }

  delete = (guest: Guest) => {
    this.confirmationService.confirm({
      message: 'Are you sure?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (guest.id) {
          this.loading = true;
          firstValueFrom(await this.guestService.delete(guest.id));
          this.loading = true;

          await this.refreshGrid();
        }
      }
    });
  }
}
