import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Invitation } from '../../core/invitation';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Guest } from '../../core/guest';
import { GuestService } from '../../core/guest.service';

@Component({
  selector: 'app-guest-list',
  templateUrl: './guest-list.component.html',
  styleUrl: './guest-list.component.scss'
})
export class GuestListComponent implements OnInit {
  eventId: string | undefined;

  dialog: boolean = false;

  items: Guest[] = [];

  item: Guest = {};

  selectedItems: Guest[] | null = [];

  submitted: boolean = false;

  constructor(private service: GuestService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.refreshGrid();
  }

  refreshGrid = async () => {
    const res = await this.service.getAll();
    if (res?.data) this.items = res.data;
  }

  openNew = () => {
    this.item = {};
    this.submitted = false;
    this.dialog = true;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Items Deleted', life: 3000 });
      }
    });
  }

  edit = (invitation: Invitation) => {
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

  save = async () => {
    this.submitted = true;

    if (this.item?.firstName?.trim() && this.item?.lastName?.trim()) {
      if (this.item.id) {
        await this.service.update(this.item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
      else {
        await this.service.add(this.item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }

      this.items = [...this.items];
      this.dialog = false;
      this.item = {};
    }
  }
}
