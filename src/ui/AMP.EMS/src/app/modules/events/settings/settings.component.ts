import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';

import { Event } from '../../../core/models/event';

import { Column } from '../../../core/models/column';
import { Table } from 'primeng/table';
import { EventType } from '../../../core/models/event-type';
import { EventTypeService } from '../../../core/services/event-type.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html'
})
export class AppSettingsComponent implements OnInit {
  items!: Event[];

  selectedItems!: EventType[];

  eventTypeCollection!: EventType[];

  columns!: Column[];

  loading: boolean = true;

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventTypeService: EventTypeService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  loadEventTypes = async () => {
    this.eventTypeCollection = await this.eventTypeService.getAll();
  }

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.eventTypeService.getAll();

    if (res?.data) this.items = res.data;

    this.loading = false;
  }

  addRow = async () => {
    await this.loadEventTypes();
    await this.refreshGrid();

    this.items.unshift({});

    this.table.initRowEdit(this.items[0]);

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

        await this.eventTypeService.deleteSelected([]);
        await this.refreshGrid();

        this.loading = false;
      }
    });
  }

  delete = async (itemToDelete: EventType) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          this.loading = true;

          await this.eventTypeService.delete(itemToDelete.id);
          await this.refreshGrid();

          this.loading = false;
        }
      }
    });
  }

  initTableEdit = () => {
    console.log("Edit");
  }

  save = async (item: EventType | undefined) => {
    if (item?.name?.trim()) {
      this.loading = true;

      if (item.id) {
        await this.eventTypeService.update(item);
        await this.refreshGrid();
      }
      else {
        await this.eventTypeService.add(item);
        await this.refreshGrid();
      }

      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
  }
}
