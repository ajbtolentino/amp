import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RsvpService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { GuestInvitationService } from '@modules/event';
import { GuestInvitation, Invitation } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';
import { EventInvitationService } from '../../services/event-invitation.service';

@Component({
  selector: 'app-event-invitation-list',
  templateUrl: './event-invitation-list.component.html'
})
export class EventInvitationListComponent implements OnInit {
  eventId!: string;

  eventInvitations$: Observable<Invitation[]> = new Observable<Invitation[]>();

  selectedItems: Invitation[] | null = [];

  @ViewChild('dt') table!: Table;

  templateCode!: string;

  constructor(private eventService: EventService,
    private eventInvitationService: EventInvitationService,
    private eventGuestInvitationService: GuestInvitationService,
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

  loadEventGuestInvitation = (eventInvitations: Invitation[]): Observable<Invitation[]> => {
    return this.eventGuestInvitationService.getByInvitationIds(eventInvitations.map(_ => _.id!))
      .pipe(
        switchMap(eventGuestInvitations => this.loadRsvp(eventGuestInvitations)),
        map(eventGuestInvitations => {
          return eventInvitations.map(eventInvitation => {
            return {
              ...eventInvitation,
              eventGuestInvitations: eventGuestInvitations.filter(_ => _.invitationId === eventInvitation.id)
            }
          })
        })
      );
  }

  loadRsvp = (eventGuestInvitations: GuestInvitation[]): Observable<GuestInvitation[]> => {
    if (!eventGuestInvitations.length) return of<GuestInvitation[]>([]);

    return this.rsvpService.getByGuestInvitationIds(eventGuestInvitations.map(_ => _.id!))
      .pipe(
        map(eventGuestInvitationRsvps => {
          return eventGuestInvitations.map(eventGuestInvitation => {
            return {
              ...eventGuestInvitation,
              eventGuestInvitationRsvps: eventGuestInvitationRsvps.filter(_ => _.guestInvitationId === eventGuestInvitation.id)
            }
          })
        }))
  }

  getTotalAccepted = (eventGuestInvitation: GuestInvitation): boolean => {
    if (!eventGuestInvitation?.guestInvitationRsvps?.length)
      return false;

    let items = eventGuestInvitation?.guestInvitationRsvps.filter(_ => _.dateCreated);

    items = items.sort((a, b) => {
      return new Date(b.dateCreated!).getTime() - new Date(a.dateCreated!).getTime()
    });

    return items[0].response === "ACCEPT";
  }


  getTotalDeclined = (eventGuestInvitation: GuestInvitation): boolean => {
    if (!eventGuestInvitation?.guestInvitationRsvps?.length)
      return false;

    let items = eventGuestInvitation?.guestInvitationRsvps.filter(_ => _.dateCreated);

    items = items.sort((a, b) => {
      return new Date(b.dateCreated!).getTime() - new Date(a.dateCreated!).getTime()
    });

    return items[0].response === "DECLINE";
  }

  delete = (invitation: Invitation) => {
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
