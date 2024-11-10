import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RsvpService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { EventGuestInvitationService } from '@modules/event/guest';
import { EventInvitationService } from '@modules/event/invitation/services/event-invitation.service';
import { EventGuestInvitation, EventInvitation } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';

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
    private eventGuestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.refreshGrid();
  }

  refreshGrid = () => {
    this.eventInvitations$ = this.eventService.getInvitations(this.eventId).pipe(
      switchMap(eventInvitations => this.loadEventGuestInvitation(eventInvitations))
    );
  }

  loadEventGuestInvitation = (eventInvitations: EventInvitation[]): Observable<EventInvitation[]> => {
    return this.eventGuestInvitationService.getByEventInvitationIds(eventInvitations.map(_ => _.id!))
      .pipe(
        switchMap(eventGuestInvitations => this.loadRsvp(eventGuestInvitations)),
        map(eventGuestInvitations => {
          return eventInvitations.map(eventInvitation => {
            return {
              ...eventInvitation,
              eventGuestInvitations: eventGuestInvitations.filter(_ => _.eventInvitationId === eventInvitation.id)
            }
          })
        })
      );
  }

  loadRsvp = (eventGuestInvitations: EventGuestInvitation[]): Observable<EventGuestInvitation[]> => {
    if (!eventGuestInvitations.length) return of<EventGuestInvitation[]>([]);

    return this.rsvpService.getByEventGuestInvitationIds(eventGuestInvitations.map(_ => _.id!))
      .pipe(
        map(eventGuestInvitationRsvps => {
          return eventGuestInvitations.map(eventGuestInvitation => {
            return {
              ...eventGuestInvitation,
              eventGuestInvitationRsvps: eventGuestInvitationRsvps.filter(_ => _.eventGuestInvitationId === eventGuestInvitation.id)
            }
          })
        }))
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
