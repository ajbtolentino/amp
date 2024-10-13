import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Invitation } from '../../core/models/invitation';
import { InvitationService } from '../../core/services/invitation.service';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { Guest } from '../../core/models/guest';
import { Event } from '../../core/models/event';

import { GuestService } from '../../core/services/guest.service';
import { EventService } from '../../core/services/event.service';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { CheckboxModule } from 'primeng/checkbox';
import { ToolbarModule } from 'primeng/toolbar';

@Component({
  standalone: true,
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss',
  imports: [
    TableModule,
    ButtonModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    CommonModule,
    RouterModule,
    TooltipModule,
    CheckboxModule,
    ToolbarModule
  ]
})
export class EventDetailsComponent implements OnInit {
  guestCollection: Guest[] | undefined;

  eventId: string | undefined;

  event: Event | undefined;

  items: Invitation[] = [];

  item: Invitation = {};

  isCreating: boolean = false;

  selectedItems: Invitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

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

    this.item = {};
    this.items.unshift(this.item);
    this.isCreating = true;
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
    this.item = { ...invitation };
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
    this.item = item;

    if (this.item?.code?.trim() && this.item.guestId?.trim()) {
      this.loading = true;

      this.item.eventId = this.eventId;

      if (this.item.id) {
        await this.invitationService.update(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Updated', life: 3000 });
      }
      else {
        await this.invitationService.add(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Created', life: 3000 });
      }

      this.item = {};
      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
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
