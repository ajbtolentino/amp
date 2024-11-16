import { Component, OnInit, ViewChild } from '@angular/core';
import { LookupService } from '@core/services';
import { Column, EventType } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-event-type-list',
  templateUrl: './event-type-list.component.html',
  styleUrl: './event-type-list.component.scss'
})
export class EventTypeListComponent implements OnInit {
  items!: Event[];

  selectedItems!: EventType[];

  eventTypes$: Observable<EventType[]> = new Observable<EventType[]>();

  columns!: Column[];

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private lookupService: LookupService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.eventTypes$ = this.lookupService.getAll('eventType');

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
        this.lookupService.deleteSelected('eventtype', []);
      }
    });
  }

  refreshGrid = () => {
    this.eventTypes$ = this.lookupService.getAll('eventtype');
  }

  delete = (itemToDelete: EventType) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          lastValueFrom(this.lookupService.delete('eventtype', itemToDelete.id!)).then(this.refreshGrid);
        }
      }
    });
  }

  initTableEdit = () => {
  }

  save = (item: EventType | undefined) => {
    if (item?.name?.trim()) {
      if (item.id) {
        lastValueFrom(this.lookupService.update('eventtype', item)).then(this.refreshGrid);
      }
      else {
        lastValueFrom(this.lookupService.add('eventtype', item)).then(this.refreshGrid);
      }
    }

    this.isCreating = false;
  }
}