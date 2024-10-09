import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Invitation } from '../../core/models/invitation';
import { InvitationService } from '../../core/services/invitation.service';
import { ActivatedRoute } from '@angular/router';

import { Guest } from '../../core/models/guest';
import { Event } from '../../core/models/event';

import { GuestService } from '../../core/services/guest.service';
import { EventService } from '../../core/services/event.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss'
})
export class EventDetailsComponent implements OnInit {
  guestCollection: Guest[] | undefined;

  eventId: string | undefined;

  event: Event | undefined;

  dialog: boolean = false;

  items: Invitation[] = [];

  item: Invitation = {};

  selectedItems: Invitation[] | null = [];

  submitted: boolean = false;

  constructor(private eventService: EventService,
    private invitationService: InvitationService,
    private guestService: GuestService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.paramMap.get('id')?.toString();
    this.refreshGrid();
  }

  refreshGrid = async () => {
    if (this.eventId) {
      const eventResponse = await this.eventService.get(this.eventId);
      if (eventResponse?.data) this.event = eventResponse.data;

      const res = await this.invitationService.getAll(this.eventId);
      if (res?.data) this.items = res.data;
    }
  }

  openNew = async () => {
    await this.loadGuests();
    this.item = {};
    this.generateCode(5);
    this.submitted = false;
    this.dialog = true;
  }

  deleteSelectedEvents = () => {
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
    const res = await this.guestService.getAll();
    if (res?.data) this.guestCollection = res.data;
  }

  edit = async (invitation: Invitation) => {
    await this.loadGuests();
    this.item = { ...invitation };
    this.dialog = true;
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

  hideDialog() {
    this.dialog = false;
    this.submitted = false;
  }

  saveEvent = async () => {
    this.submitted = true;

    if (this.item?.code?.trim() && this.item.guestId?.trim()) {
      this.item.eventId = this.eventId;

      if (this.item.id) {
        await this.invitationService.update(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Updated', life: 3000 });
      }
      else {
        await this.invitationService.add(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Created', life: 3000 });
      }

      await this.refreshGrid();

      this.dialog = false;
      this.item = {};
    }
  }

  generateCode = (length: number) => {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    const charactersLength = characters.length;
    let counter = 0;

    while (counter < length) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
      counter += 1;
    }

    this.item.code = result;
  }
}
