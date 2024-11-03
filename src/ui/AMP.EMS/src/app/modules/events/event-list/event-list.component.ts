import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';


import { EventService } from '../../../core/services/event.service';
import { Table } from 'primeng/table';
import { EventTypeService } from '../../../core/services/event-type.service';
import { Observable } from 'rxjs';
import { Column, Event, EventType } from '@shared/models';

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

  loading: boolean = true;

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private eventTypeService: EventTypeService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  refreshGrid = async () => {
    this.loading = true;

    this.events$ = this.eventService.getAll();

    this.loading = false;
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
        }
      }
    });
  }

  save = async (item: Event | undefined) => {
    if (item?.title?.trim()) {
      this.loading = true;

      if (item.id) {
        await this.eventService.update(item);
        await this.refreshGrid();
      }
      else {
        await this.eventService.add(item);
        await this.refreshGrid();
      }

      this.loading = false;
    }

    await this.refreshGrid();
  }
}
