import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services/event.service';
import { EventInvitationService } from '@modules/event/invitation/services/event-invitation.service';
import { EventGuestInvitation, EventInvitation } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Observable, switchMap } from 'rxjs';

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
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.refreshGrid();
  }

  refreshGrid = () => {
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId);
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

  deleteSelectedItems = () => {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected invitations?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.eventInvitations$ = this.eventInvitationService.deleteSelected(this.selectedItems!.map(_ => _.id!)).pipe(switchMap(() => this.eventInvitationService.getAll()));
      }
    });
  }
}
