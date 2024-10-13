import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Invitation } from '../../../core/models/invitation';
import { InvitationService } from '../../../core/services/invitation.service';
import { ActivatedRoute } from '@angular/router';

import { Guest } from '../../../core/models/guest';
import { Event } from '../../../core/models/event';

import { GuestService } from '../../../core/services/guest.service';
import { EventService } from '../../../core/services/event.service';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss',
})
export class EventDetailsComponent implements OnInit {
  guestCollection: Guest[] | undefined;

  eventId: string | undefined;

  event: Event | undefined;

  items: Invitation[] = [];

  isCreating: boolean = false;

  selectedItems: Invitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  constructor(private eventService: EventService,
    private invitationService: InvitationService,
    private guestService: GuestService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(data => {
      const eventId = data.get("id");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
      }
    });
  }

  refreshGrid = async () => {
    this.loading = true;

    if (this.eventId) {
      const eventResponse = await this.eventService.get(this.eventId);
      if (eventResponse?.data) this.event = eventResponse.data;

      const res = await this.invitationService.getAll(this.eventId);
      if (res?.data) this.items = res.data;
    }

    this.loading = false;
  }

  addRow = async () => {
    await this.refreshGrid();
    await this.loadGuests();

    this.items.unshift({});
    this.isCreating = true;

    this.table.initRowEdit(this.items[0]);
  }

  editRow = async () => {
    this.isCreating = false;
    await this.loadGuests();
  }

  cancelAdd = async () => {
    await this.refreshGrid();
    this.isCreating = false;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
    });
  }

  loadGuests = async () => {
    this.loading = true;

    const res = await this.guestService.getAll();
    if (res?.data) this.guestCollection = res.data;

    this.loading = false;
  }

  edit = async (invitation: Invitation) => {
    await this.loadGuests();
  }

  delete = async (invitation: Invitation) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + invitation.code + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (invitation.id) {
          await this.invitationService.delete(invitation.id);
          await this.refreshGrid();
          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
        }
      }
    });
  }

  save = async (item: Invitation) => {
    item.eventId = this.eventId;

    if (item?.code?.trim() && item.guestId?.trim()) {
      this.loading = true;


      if (item.id) {
        await this.invitationService.update(item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Updated', life: 3000 });
      }
      else {
        await this.invitationService.add(item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Created', life: 3000 });
      }

      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
  }

  generateCode = (item: Invitation, length: number) => {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    const charactersLength = characters.length;
    let counter = 0;

    while (counter < length) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
      counter += 1;
    }

    item.code = result;
  }
}
