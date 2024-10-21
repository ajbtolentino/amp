import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { EventGuest } from '../../../core/models/event-guest';
import { EventService } from '../../../core/services/event.service';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';

@Component({
  selector: 'app-event-guest-invitation',
  templateUrl: './event-guest-invitation.component.html',
  styles: ``
})
export class EventGuestInvitationComponent implements OnInit {
  guestCollection: EventGuest[] | undefined;

  eventInvitationId: string | undefined;

  event: Event | undefined;

  items: EventGuestInvitation[] = [];

  isCreating: boolean = false;

  selectedItems: EventGuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;


  loading: boolean = true;

  templateCode!: string;

  constructor(private eventService: EventService,
    private eventGuestInvitationService: EventGuestInvitationService,
    private guestService: EventGuestService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    @Inject(DOCUMENT) private document: Document) { }

  async ngOnInit() {
    this.route.parent?.paramMap.subscribe(data => {
      const eventInvitationId = data.get("id");

      if (eventInvitationId) this.eventInvitationId = eventInvitationId;


      this.refreshGrid();
    });
  }

  refreshGrid = async () => {
    this.loading = true;

    if (this.eventInvitationId) {
      const eventResponse = await this.eventService.get(this.eventInvitationId);
      if (eventResponse?.data) this.event = eventResponse.data;

      const eventInvitationResponse = await this.eventGuestInvitationService.getAll(this.eventInvitationId);
      if (eventInvitationResponse?.data) this.items = eventInvitationResponse.data;
    }
    else {
      const eventInvitationResponse = await this.eventGuestInvitationService.getAll();
      if (eventInvitationResponse?.data) this.items = eventInvitationResponse.data;
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
      message: 'Are you sure you want to delete the selected invitations?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
      }
    });
  }

  loadGuests = async () => {
    this.loading = true;

    const res = await this.guestService.getAll();
    if (res?.data) this.guestCollection = res.data;

    this.loading = false;
  }

  edit = async (invitation: EventGuestInvitation) => {
    await this.loadGuests();
  }

  delete = async (invitation: EventGuestInvitation) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (invitation.id) {
          await this.eventGuestInvitationService.delete(invitation.id);
          await this.refreshGrid();
        }
      }
    });
  }

  save = async (item: EventGuestInvitation) => {
    item.eventInvitationId = this.eventInvitationId;

    if (item?.id?.trim()) {
      this.loading = true;

      if (item.id) {
        await this.eventGuestInvitationService.update(item);
      }
      else {
        await this.eventGuestInvitationService.add(item);
      }

      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
  }

  generateCode = (item: EventGuestInvitation, length: number) => {
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
