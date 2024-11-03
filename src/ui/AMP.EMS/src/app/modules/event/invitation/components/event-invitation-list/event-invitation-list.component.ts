import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Observable } from 'rxjs';
import { EventInvitation, EventInvitationInfo } from '@shared/models';
import { EventService } from '@core/services/event.service';
import { EventInvitationService } from '../../services/event-invitation.service';

@Component({
  selector: 'app-event-invitation-list',
  templateUrl: './event-invitation-list.component.html'
})
export class EventInvitationListComponent implements OnInit {
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

  getTotalRecipients = (eventInvitation: EventInvitation): number => {
    return eventInvitation.eventGuestInvitations?.length || 0;
  }

  getTotalCapacity = (eventInvitation: EventInvitation): number => {
    return eventInvitation.eventGuestInvitations?.reduce((a, b) => a + (b.eventGuest?.maxGuests ?? 0), 0) || 0;
  }

  getTotalAccepted = (eventInvitation: EventInvitation): number => {
    let total = 0;

    for (let eventGuestInvitation of eventInvitation.eventGuestInvitations || []) {
      if (eventGuestInvitation.eventGuestInvitationRsvps?.length && eventGuestInvitation?.eventGuestInvitationRsvps[0].response === "ACCEPT")
        total++;
    }

    return total;
  }


  getActualGuests = (eventInvitationInfo: EventInvitationInfo): number => {
    let total = 0;

    for (let eventGuestInvitations of eventInvitationInfo.eventGuestInvitations || []) {
      if (eventGuestInvitations.rsvps?.length && eventGuestInvitations.rsvps[0].response === "ACCEPT") {
        for (let name of eventGuestInvitations.rsvps[0].guestNames || []) {
          if (name) total++;
        }
      }
    }
    return total
  }

  getTotalDeclined = (eventInvitationInfo: EventInvitationInfo): number => {
    let total = 0;

    for (let eventGuestInvitations of eventInvitationInfo.eventGuestInvitations || []) {
      if (eventGuestInvitations?.rsvps?.length && eventGuestInvitations?.rsvps[0].response === "DECLINE")
        total++;
    }

    return total;
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
