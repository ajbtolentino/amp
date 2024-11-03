import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService, LazyLoadEvent } from 'primeng/api';
import { MessageService } from 'primeng/api';


import { Table, TableLazyLoadEvent } from 'primeng/table';
import { EventTypeService } from '../../../core/services/event-type.service';
import { lastValueFrom, Observable } from 'rxjs';
import { Column, EventType } from '@shared/models';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html'
})
export class AppSettingsComponent implements OnInit {
  items!: Event[];

  selectedItems!: EventType[];

  eventTypes$: Observable<EventType[]> = new Observable<EventType[]>();

  columns!: Column[];

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventTypeService: EventTypeService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.eventTypes$ = this.eventTypeService.getAll();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  addRow = async (eventTypes: EventType[]) => {
    eventTypes.unshift({});

    this.table.initRowEdit(eventTypes[0]);

    this.isCreating = true;
  }

  editRow = () => {
    this.isCreating = false;
  }

  cancelAdd = async () => {
    this.isCreating = false;
    this.refreshGrid();
  }

  deleteSelectedItems = async () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.eventTypeService.deleteSelected([]);
      }
    });
  }

  refreshGrid = () => {
    this.eventTypes$ = this.eventTypeService.getAll();
  }

  delete = (itemToDelete: EventType) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          lastValueFrom(this.eventTypeService.delete(itemToDelete.id!)).then(this.refreshGrid);
        }
      }
    });
  }

  initTableEdit = () => {
    console.log("Edit");
  }

  save = (item: EventType | undefined) => {
    if (item?.name?.trim()) {
      if (item.id) {
        lastValueFrom(this.eventTypeService.update(item)).then(this.refreshGrid);
      }
      else {
        lastValueFrom(this.eventTypeService.add(item)).then(this.refreshGrid);
      }
    }

    this.isCreating = false;
  }
}
