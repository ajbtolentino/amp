import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';

import { Event } from '../../../core/models/event';

import { EventService } from '../../../core/services/event.service';
import { Column } from '../../../core/models/column';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { Table, TableModule } from 'primeng/table';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { TooltipModule } from 'primeng/tooltip';
import { ToolbarModule } from 'primeng/toolbar';
import { EventType } from '../../../core/models/event-type';
import { EventTypeService } from '../../../core/services/event-type.service';

@Component({
  selector: 'app-event-types',
  templateUrl: './event-types.component.html',
  styleUrl: './event-types.component.scss',
})
export class EventTypesComponent implements OnInit {
  items!: Event[];

  selectedItems!: EventType[];

  eventTypeCollection!: EventType[];

  columns!: Column[];

  loading: boolean = true;

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventTypeService: EventTypeService,
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

        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
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

          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
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
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
      else {
        await this.eventTypeService.add(item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }

      this.loading = false;
    }

    await this.refreshGrid();
    this.isCreating = false;
  }
}
