import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';

import { Event } from '../../core/models/event';

import { EventService } from '../../core/services/event.service';

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

  submitted: boolean = false;

  constructor(private eventService: EventService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.refreshGrid();
  }

  refreshGrid = async () => {
    const res = await this.eventService.getAll();

    if (res?.data) this.items = res.data;
  }

  openNew = () => {
    this.event = {};
    this.submitted = false;
    this.dialog = true;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
    });
  }

  edit = (item: Event) => {
    this.event = { ...item };
    this.dialog = true;
  }

  delete = async (item: Event) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + item.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (item.id) {
          await this.eventService.delete(item.id);
          await this.refreshGrid();
          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
        }
      }
    });
  }

  hideDialog() {
    this.dialog = false;
    this.submitted = false;
  }

  save = async () => {
    this.submitted = true;

    if (this.event?.name?.trim()) {
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

      this.items = [...this.items];
      this.dialog = false;
      this.event = {};
    }
  }
}
