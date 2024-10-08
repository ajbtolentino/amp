import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { EventService } from './event.service';
import { Event } from './event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styles: [`
    :host ::ng-deep .p-dialog .product-image {
        width: 150px;
        margin: 0 auto 2rem auto;
        display: block;
    }
`],
  styleUrl: './events.component.scss'
})
export class EventsComponent implements OnInit {
  eventDialog: boolean = false;

  events: Event[] = [];

  event: Event = {};

  selectedEvents: Event[] | null = [];

  submitted: boolean = false;

  constructor(private eventService: EventService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.eventService.getEvents().then(data => {
      console.log(data);
      this.events = data;
    }
    );
  }

  openNew() {
    this.event = {};
    this.submitted = false;
    this.eventDialog = true;
  }

  deleteSelectedEvents() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.events = this.events.filter(val => !this.selectedEvents?.includes(val));
        this.selectedEvents = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
      }
    });
  }

  editEvent(product: Event) {
    this.event = { ...product };
    this.eventDialog = true;
  }

  deleteEvent(event: Event) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + event.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.events = this.events.filter(val => val.id !== event.id);
        this.event = {};
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Event Deleted', life: 3000 });
      }
    });
  }

  hideDialog() {
    this.eventDialog = false;
    this.submitted = false;
  }

  saveEvent() {
    this.submitted = true;

    if (this.event?.name?.trim()) {
      if (this.event.id) {
        this.events[this.findIndexById(this.event.id)] = this.event;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Updated', life: 3000 });
      }
      else {
        this.event.id = this.createId();
        // this.event.image = 'product-placeholder.svg';
        this.events.push(this.event);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Created', life: 3000 });
      }

      this.events = [...this.events];
      this.eventDialog = false;
      this.event = {};
    }
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.events.length; i++) {
      if (this.events[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }
}
