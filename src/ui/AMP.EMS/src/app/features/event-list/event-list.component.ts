import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';

import { Event } from '../../core/models/event';

import { EventService } from '../../core/services/event.service';
import { Column } from '../../core/models/column';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit {
  dialog: boolean = false;

  items: Event[] = [];

  event: Event = {};

  selectedItems: Event[] | null = [];

  columns!: Column[]

  loading: boolean = true;

  isCreating: boolean = false;

  constructor(private eventService: EventService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.eventService.getAll();

    if (res?.data) this.items = res.data;

    this.loading = false;
  }

  addRow = async () => {
    await this.refreshGrid();

    this.event = {};
    this.items.unshift(this.event);
    this.isCreating = true;
  }

  editRow = () => {
    this.isCreating = false;
  }

  cancelAdd = async () => {
    await this.refreshGrid();
    this.isCreating = false;
  }

  deleteSelectedItems = async () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.loading = true;

        await this.eventService.deleteSelected([]);
        await this.refreshGrid();

        this.selectedItems = null;

        this.loading = false;

        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
    });
  }

  delete = async (itemToDelete: Event) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          this.loading = true;

          await this.eventService.delete(itemToDelete.id);
          await this.refreshGrid();

          this.loading = false;

          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
        }
      }
    });
  }

  save = async (item: Event | undefined) => {
    if (item) this.event = item;

    if (this.event?.name?.trim()) {
      this.loading = true;

      if (this.event.id) {
        await this.eventService.update(this.event);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Event Updated', life: 3000 });
      }
      else {
        await this.eventService.add(this.event);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Event Created', life: 3000 });
      }

      this.loading = false;

      this.event = {};
    }

    await this.refreshGrid();
    this.isCreating = false;
  }
}
