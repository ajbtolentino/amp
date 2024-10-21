import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

import { EventGuest } from '../../../core/models/event-guest';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { Table } from 'primeng/table';
import { EventService } from '../../../core/services/event.service';

@Component({
  selector: 'app-event-guests',
  templateUrl: './event-guests.component.html',
  styleUrl: './event-guests.component.scss'
})
export class EventGuestsComponent implements OnInit {
  eventId!: string;

  items: EventGuest[] = [];

  selectedItems: EventGuest[] | null = [];

  isCreating: boolean = false;

  loading: boolean = true;

  @ViewChild('dt') table!: Table;

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

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.eventService.getGuests(this.eventId);
    if (res?.data) this.items = res.data;

    this.loading = false;
    this.isCreating = false;
  }

  hasResponded = (item: EventGuest) => {
    return item.eventGuestInvitations?.filter(_ => _.eventGuestInvitationRSVPs?.length).length || false;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.loading = true;

        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;

        this.loading = false;

        this.refreshGrid();
      }
    });
  }

  delete = async (guest: EventGuest) => {
    this.confirmationService.confirm({
      message: 'Are you sure?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (guest.id) {
          this.loading = true;
          await this.eventGuestService.delete(guest.id);
          this.loading = true;

          await this.refreshGrid();
        }
      }
    });
  }
}
