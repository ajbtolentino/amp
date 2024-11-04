import { Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Observable, switchMap, tap } from 'rxjs';
import { EventGuestInvitation, EventGuestInvitationRsvp, EventInvitation, EventInvitationInfo } from '@shared/models';
import { EventService } from '@core/services/event.service';
import { EventInvitationService } from '../../services/event-invitation.service';

@Component({
  selector: 'app-event-invitation-list',
  templateUrl: './event-invitation-list.component.html'
})
export class EventInvitationListComponent implements OnInit {
  eventId!: string;

  eventInvitations$: Observable<EventInvitation[]> = new Observable<EventInvitation[]>();

  selectedItems: EventInvitation[] | null = [];

  @ViewChild('dt') table!: Table;

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
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
  }

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected invitations?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.selectedItems = null;
      }
    });
  }

  getTotalAccepted = (eventGuestInvitation: EventGuestInvitation): boolean => {
    if (!eventGuestInvitation?.eventGuestInvitationRsvps?.length)
      return false;

    let items = eventGuestInvitation?.eventGuestInvitationRsvps.filter(_ => _.dateCreated);

    items = items.sort((a, b) => {
      return new Date(b.dateCreated!).getTime() - new Date(a.dateCreated!).getTime()
    });

    return items[0].response === "ACCEPT";
  }


  getTotalDeclined = (eventGuestInvitation: EventGuestInvitation): boolean => {
    if (!eventGuestInvitation?.eventGuestInvitationRsvps?.length)
      return false;

    let items = eventGuestInvitation?.eventGuestInvitationRsvps.filter(_ => _.dateCreated);

    items = items.sort((a, b) => {
      return new Date(b.dateCreated!).getTime() - new Date(a.dateCreated!).getTime()
    });

    return items[0].response === "DECLINE";
  }

  delete = (invitation: EventInvitation) => {
    if (invitation.id) {
      this.confirmationService.confirm({
        message: 'Are you sure you want to delete?',
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.eventInvitations$ = this.eventInvitationService.delete(invitation.id!).pipe(switchMap(() => this.eventInvitationService.getAll()));
        }
      });
    }
  }
}
