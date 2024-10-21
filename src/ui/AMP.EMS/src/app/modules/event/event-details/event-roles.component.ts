import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, EventType } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Column } from '../../../core/models/column';
import { EventRole } from '../../../core/models/event-role';
import { EventRoleService } from '../../../core/services/event-role.service';
import { EventService } from '../../../core/services/event.service';

@Component({
  selector: 'app-event-roles',
  templateUrl: './event-roles.component.html',
  styles: ``
})
export class EventRolesComponent {
  eventId!: string;

  items!: EventRole[];

  selectedItems!: EventType[];

  eventTypeCollection!: EventType[];

  columns!: Column[];

  loading: boolean = true;

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private eventRoleService: EventRoleService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
        console.log(this.eventId);
      }
    });

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  loadEventTypes = async () => {
    this.eventTypeCollection = await this.eventRoleService.getAll();
  }

  refreshGrid = async () => {
    this.loading = true;

    const res = await this.eventService.getRoles(this.eventId);

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

        await this.eventRoleService.deleteSelected([]);
        await this.refreshGrid();

        this.loading = false;
      }
    });
  }

  delete = async (itemToDelete: EventRole) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          this.loading = true;

          await this.eventRoleService.delete(itemToDelete.id);
          await this.refreshGrid();

          this.loading = false;
        }
      }
    });
  }

  initTableEdit = () => {
    console.log("Edit");
  }

  save = async (item: EventRole | undefined) => {
    if (item?.name?.trim()) {
      this.loading = true;
      item.eventId = this.eventId;

      if (item.id) {
        await this.eventRoleService.update(item);
      }
      else {
        await this.eventRoleService.add(item);
      }

      this.loading = false;

      await this.refreshGrid();
    }

    await this.refreshGrid();
    this.isCreating = false;
  }
}
