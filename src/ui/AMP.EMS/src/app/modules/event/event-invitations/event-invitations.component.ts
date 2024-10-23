import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { EventInvitation } from '../../../core/models/event-invitation';
import { EventInvitationService as EventInvitationService } from '../../../core/services/event-invitation.service';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '../../../core/services/event.service';
import { Table } from 'primeng/table';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-event-invitations',
  templateUrl: './event-invitations.component.html'
})
export class EventInvitationsComponent implements OnInit {
  eventId!: string;

  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();

  isCreating: boolean = false;

  selectedItems: EventInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = false;

  templateCode!: string;

  constructor(private eventService: EventService,
    private eventInvitationService: EventInvitationService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.refreshGrid();
      }
    });

  }

  refreshGrid = async () => {
    this.loading = true;

    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);

    this.loading = false;
  }

  addRow = async () => {
    await this.refreshGrid();

    // this.eventInvitations$.unshift({});
    this.isCreating = true;

    // this.table.initRowEdit(this.eventInvitations$[0]);
  }

  editRow = async () => {
    this.isCreating = false;
  }

  cancelAdd = async () => {
    await this.refreshGrid();
    this.isCreating = false;
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected invitations?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        // this.eventInvitations$ = this.eventInvitations$.filter(val => !this.selectedItems?.includes(val));
        this.selectedItems = null;
      }
    });
  }

  delete = async (invitation: EventInvitation) => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (invitation.id) {
          await this.eventInvitationService.delete(invitation.id);
          await this.refreshGrid();
        }
      }
    });
  }
}