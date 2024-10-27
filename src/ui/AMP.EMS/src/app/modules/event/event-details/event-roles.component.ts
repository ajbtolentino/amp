import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, EventType } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Column } from '../../../core/models/column';
import { EventGuestRole } from '../../../core/models/event-guest-role';
import { EventService } from '../../../core/services/event.service';
import { lastValueFrom, Observable } from 'rxjs';
import { EventGuestRoleService } from '../../../core/services/event-guest-role.service';

@Component({
  selector: 'app-event-roles',
  templateUrl: './event-roles.component.html',
  styles: ``
})
export class EventRolesComponent {
  eventId!: string;

  eventRoles$: Observable<EventGuestRole[]> = new Observable<EventGuestRole[]>();

  columns!: Column[];

  loading: boolean = true;

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private eventService: EventService,
    private eventGuestRoleService: EventGuestRoleService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
      }
    });

    this.columns = [
      { field: 'id', header: 'Id', customExportHeader: 'Id' },
      { field: 'name', header: 'Name' },
    ];
  }

  refreshGrid = () => {
    this.eventRoles$ = this.eventService.getRoles(this.eventId);
  }

  addRow = (eventRoles: EventGuestRole[]) => {
    eventRoles.unshift({});

    this.table.initRowEdit(eventRoles[0]);

    this.isCreating = true;
  }

  editRow = () => {
    this.isCreating = false;
  }

  cancelAdd = async () => {
    this.refreshGrid();
    this.isCreating = false;
  }

  deleteSelectedItems = async () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected events?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.loading = true;

        this.refreshGrid();

        this.loading = false;
      }
    });
  }

  delete = async (itemToDelete: EventGuestRole) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + itemToDelete.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (itemToDelete.id) {
          this.loading = true;

          await this.eventGuestRoleService.delete(itemToDelete.id);
          this.refreshGrid();

          this.loading = false;
        }
      }
    });
  }

  initTableEdit = () => {
  }

  save = async (item: EventGuestRole) => {
    if (item?.name?.trim()) {
      this.loading = true;

      if (item.id) {
        await lastValueFrom(this.eventGuestRoleService.update(item));
      }
      else {
        item.eventId = this.eventId;
        await lastValueFrom(this.eventGuestRoleService.add(item));
      }

      this.loading = false;

      this.refreshGrid();
    }

    this.refreshGrid();
    this.isCreating = false;
  }
}
