import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Invitation } from '../../core/invitation';
import { InvitationService } from '../../core/invitation.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { GuestService } from '../../core/guest.service';
import { Guest } from '../../core/guest';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss'
})
export class EventDetailsComponent implements OnInit {
  guestCollection: Guest[] | undefined;

  eventId: string | undefined;

  dialog: boolean = false;

  items: Invitation[] = [];

  item: Invitation = {};

  selectedItems: Invitation[] | null = [];

  submitted: boolean = false;

  constructor(private service: InvitationService,
    private guestService: GuestService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.paramMap.get('eventId')?.toString();

    this.route.paramMap.pipe(
      switchMap(params => {
        this.eventId = params.get('eventId')?.toString();
        return this.refreshGrid();
      })
    );

    this.refreshGrid();
  }

  refreshGrid = async () => {
    if (this.eventId) {
      const res = await this.service.getAll(this.eventId);
      if (res?.data) this.items = res.data;
    }
  }

  openNew = async () => {
    await this.loadGuests();
    this.item = {};
    this.submitted = false;
    this.dialog = true;
  }

  deleteSelectedEvents = () => {
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

  loadGuests = async () => {
    const res = await this.guestService.getAll();
    if (res?.data) this.guestCollection = res.data;
  }

  edit = async (invitation: Invitation) => {
    await this.loadGuests();
    this.item = { ...invitation };
    this.dialog = true;
  }

  delete = async (invitation: Invitation) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + invitation.code + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (invitation.id) {
          await this.service.delete(invitation.id);
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

  saveEvent = async () => {
    this.submitted = true;

    if (this.item?.code?.trim() && this.item.guestId?.trim()) {
      this.item.eventId = this.eventId;

      if (this.item.id) {
        await this.service.update(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Updated', life: 3000 });
      }
      else {
        await this.service.add(this.item);

        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item Created', life: 3000 });
      }

      await this.refreshGrid();

      this.dialog = false;
      this.item = {};
    }
  }
}
