import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';

import { Event } from '../../../core/models/event';

import { EventService } from '../../../core/services/event.service';
import { Column } from '../../../core/models/column';
import { Table } from 'primeng/table';
import { EventType } from '../../../core/models/event-type';
import { EventTypeService } from '../../../core/services/event-type.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit {
  dialog: boolean = false;

  items: Event[] = [];

  selectedItems: Event[] | null = [];

  eventTypeCollection!: EventType[];

  columns!: Column[]

  loading: boolean = true;

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private eventTypeService: EventTypeService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  loadEventTypes = async () => {
    const response = await this.eventTypeService.getAll();

    if (response?.data) this.eventTypeCollection = response.data;
  }

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.eventService.getAll();

    if (res?.data) this.items = res.data;

    this.isCreating = false;
    this.loading = false;
  }

  addRow = async () => {
    await this.loadEventTypes();
    await this.refreshGrid();

    this.items.unshift({});

    this.table.initRowEdit(this.items[0]);

    this.isCreating = true;
  }

  editRow = async () => {
    await this.loadEventTypes();
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
      message: 'Are you sure you want to delete ' + itemToDelete.title + '?',
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

  initTableEdit = () => {
    console.log("Edit");
  }

  save = async (item: Event | undefined) => {
    if (item?.title?.trim()) {
      this.loading = true;

      if (item.id) {
        await this.eventService.update(item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Event Updated', life: 3000 });
      }
      else {
        await this.eventService.add(item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Event Created', life: 3000 });
      }

      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
  }
}
