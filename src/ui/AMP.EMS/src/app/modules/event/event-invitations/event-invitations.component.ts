import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { EventInvitation } from '../../../core/models/event-invitation';
import { EventInvitationService as EventInvitationService } from '../../../core/services/event-invitation.service';
import { ActivatedRoute } from '@angular/router';

import { Event } from '../../../core/models/event';

import { EventService } from '../../../core/services/event.service';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-event-invitations',
  templateUrl: './event-invitations.component.html'
})
export class EventInvitationsComponent implements OnInit {
  eventId: string | undefined;

  items: EventInvitation[] = [];

  isCreating: boolean = false;

  selectedItems: EventInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = false;

  templateCode!: string;

  constructor(private eventService: EventService,
    private eventInvitationService: EventInvitationService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    console.log('!')
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
      }
      console.log(this.eventId);
    });

  }

  refreshGrid = async () => {
    this.loading = true;

    const eventInvitationResponse = await this.eventInvitationService.getAll(this.eventId);
    if (eventInvitationResponse?.data) this.items = eventInvitationResponse.data;

    this.loading = false;
  }

  addRow = async () => {
    await this.refreshGrid();

    this.items.unshift({});
    this.isCreating = true;

    this.table.initRowEdit(this.items[0]);
  }

  editRow = async () => {
    this.isCreating = false;
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
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
    });
  }

  delete = async (invitation: EventInvitation) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (invitation.id) {
          await this.eventInvitationService.delete(invitation.id);
          await this.refreshGrid();
          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
        }
      }
    });
  }
}
