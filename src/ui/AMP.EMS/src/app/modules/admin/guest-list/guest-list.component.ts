import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

import { Guest } from '../../../core/models/guest';
import { GuestService } from '../../../core/services/guest.service';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { Table, TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { ToolbarModule } from 'primeng/toolbar';

@Component({
  selector: 'app-guest-list',
  templateUrl: './guest-list.component.html',
  styleUrl: './guest-list.component.scss'
})
export class GuestListComponent implements OnInit {
  eventId: string | undefined;

  items: Guest[] = [];

  selectedItems: Guest[] | null = [];

  isCreating: boolean = false;

  loading: boolean = true;

  @ViewChild('dt') table!: Table;

  constructor(private service: GuestService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.refreshGrid();
  }

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.service.getAll();
    if (res?.data) this.items = res.data;

    this.loading = false;
    this.isCreating = false;
  }

  addRow = async () => {
    await this.refreshGrid();

    this.items.unshift({});
    this.isCreating = true;

    this.table.initRowEdit(this.items[0]);
  }

  editRow = () => {
    this.isCreating = false;
  }

  cancelAdd = async () => {
    await this.refreshGrid();
    this.isCreating = false;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.loading = true;

        this.items = this.items.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Items Deleted', life: 3000 });

        this.loading = false;

        this.refreshGrid();
      }
    });
  }

  edit = (item: Guest) => {

  }

  delete = async (guest: Guest) => {
    this.confirmationService.confirm({
      message: 'Are you sure?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (guest.id) {
          this.loading = true;
          await this.service.delete(guest.id);
          this.loading = true;

          await this.refreshGrid();
          this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
        }
      }
    });
  }

  save = async (item: Guest) => {
    this.loading = true;

    if (item?.firstName?.trim() && item?.lastName?.trim()) {
      if (item.id) {
        await this.service.update(item);
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
      else {
        await this.service.add(item);
        await this.refreshGrid();
        this.messageService.add({ severity: 'success', summary: 'Successful', life: 3000 });
      }
    }

    this.loading = true;
    await this.refreshGrid();
  }
}
