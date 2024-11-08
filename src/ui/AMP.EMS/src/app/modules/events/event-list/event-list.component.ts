import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';


import { EventService } from '@core/services';
import { Column, Event, EventType } from '@shared/models';
import { Table } from 'primeng/table';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit {
  dialog: boolean = false;

  events$: Observable<Event[]> = new Observable<Event[]>();

  selectedItems: Event[] | null = [];

  eventTypeCollection!: EventType[];

  columns!: Column[]

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  refreshGrid = () => {
    this.events$ = this.eventService.getAll();
  }

  deleteSelectedItems = async () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.eventService.deleteSelected([]);
        this.refreshGrid();

        this.selectedItems = null;
      }
    });
  }

  counterArray(n: number): any[] {
    return Array(n);
  }

  delete = async (itemToDelete: Event) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.title + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          await this.eventService.delete(itemToDelete.id);
          this.refreshGrid();
        }
      }
    });
  }

  save = async (item: Event | undefined) => {
    if (item?.title?.trim()) {
      if (item.id) {
        await this.eventService.update(item);
        this.refreshGrid();
      }
      else {
        await this.eventService.add(item);
        this.refreshGrid();
      }
    }

    await this.refreshGrid();
  }
}
