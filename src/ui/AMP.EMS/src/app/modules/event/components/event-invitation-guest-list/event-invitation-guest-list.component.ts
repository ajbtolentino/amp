import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { EventInvitationService, GuestInvitationService, GuestService } from '@modules/event';
import { Guest, GuestInvitation, Invitation, PagedResult } from '@shared/models';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-invitation-guest-list',
  templateUrl: './event-invitation-guest-list.component.html',
  styles: `
  .invitation-badge {
    border-radius: var(--border-radius);
    padding: .25em .5rem;
    text-transform: uppercase;
    font-weight: 700;
    font-size: 12px;
    letter-spacing: .3px;

    &.status-not-assigned {
        background: #FEEDAF;
        color: #8A5340;
    }

    &.status-awaiting-response {
        background: #B3E5FC;
        color: #23547B;
    }

    &.status-responded {
        background: #C8E6C9;
        color: #256029;
    }

    &.status-ACCEPT {
        background: #C8E6C9 !important;
        color: #256029 !important;
    }

    &.status-DECLINE {
        background: #FFCDD2;
        color: #C63737;
    }
}
  `
})
export class EventInvitationGuestListComponent implements OnInit {
  eventId!: string;
  eventInvitationId!: string;

  invitation$: Observable<Invitation> = new Observable<Invitation>();
  guests$: Observable<PagedResult<Guest>> = new Observable<PagedResult<Guest>>();
  eventGuestInvitations: Observable<GuestInvitation> = new Observable<GuestInvitation>();

  selectedItems: GuestInvitation[] | null = [];

  maxGuestsCollection: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  @ViewChild('dt') table!: Table;

  loading: boolean = true;

  templateCode!: string;

  editGuestInvitation?: GuestInvitation;
  editGuestInvitationNames?: { name: string }[];
  showEditGuestInvitationModal: boolean = false;

  constructor(
    private eventService: EventService,
    private guestService: GuestService,
    private guestInvitationService: GuestInvitationService,
    private eventInvitationService: EventInvitationService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get('eventId') || '';
    this.eventInvitationId = this.route.snapshot.paramMap.get('eventInvitationId') || '';
    this.invitation$ = this.loadInvitation();
  }

  refreshGrid = (event: any) => {
    this.guests$ = of<PagedResult<Guest>>({ result: [], totalRecords: 0, pageNumber: 0 })
    let pageNumber = event.first / event.rows;

    this.guests$ = this.loadGuests(pageNumber, event.rows, event.filters?.global?.value, event.sortField, event.sortOrder == 1 ? 'Ascending' : 'Descending');
  }

  loadInvitation = (): Observable<Invitation> => {
    return this.eventInvitationService.get(this.eventInvitationId);
  }

  loadGuests = (pageNumber: number, rows: number, filter?: string, sortField?: string, sortDirection?: 'Ascending' | 'Descending') => {
    return this.eventService.getGuests(this.eventId, pageNumber, rows, filter, sortField, sortDirection)
      .pipe(
        switchMap(guests => this.loadGuestInvitations(guests)),
      );
  }

  loadGuestInvitations = (guests: PagedResult<Guest>): Observable<PagedResult<Guest>> => {
    return this.guestInvitationService.getByGuestIds(guests.result!.map(_ => _.id!))
      .pipe(
        map(eventGuestInvitations => ({
          totalRecords: guests.totalRecords,
          pageNumber: guests.pageNumber,
          result: guests.result!.map(guest => ({
            ...guest,
            guestInvitations: eventGuestInvitations.filter(_ => _.guestId === guest.id)
          }))
        }))
      );
  }

  loadGuest = (guests: Guest[]): Observable<Guest[]> => {
    return this.guestService.getByIds(guests.map(_ => _.guestId!))
      .pipe(
        map(guests => {
          return guests.map(eventGuest => {
            return {
              ...eventGuest,
              guest: guests.find(_ => _.id === eventGuest.guestId)
            }
          })
        })
      );
  }

  quickAdd = async (guestId: string) => {
    this.guests$ = this.guestInvitationService.add({
      guestId: guestId,
      seats: 1,
      invitationId: this.eventInvitationId
    }).pipe(
      switchMap(() => {
        const pageNumber = this.table.first! / this.table.rows!;
        const globalFilter: any = this.table?.filters['global'] || '';
        return this.loadGuests(pageNumber, this.table.rows!, globalFilter['value'] || '', this.table?.sortField || '', this.table.sortOrder == 1 ? 'Ascending' : 'Descending');
      })
    );
  }

  edit = (guestInvitation: GuestInvitation) => {
    this.editGuestInvitation = { ...guestInvitation };

    if (this.editGuestInvitation.data) {
      const data = JSON.parse(this.editGuestInvitation.data);

      if (data.guestNames && this.editGuestInvitation.seats)
        data.guestNames.length = this.editGuestInvitation.seats - 1;

      this.editGuestInvitation.data = JSON.stringify(data);
    }

    this.showEditGuestInvitationModal = true;
  }

  guestInvitationSeatChange = (event: any, data: any) => {
    if (!data?.guestNames)
      data.guestNames = [].constructor(event - 1);

    data.guestNames.length = event - 1;

    this.editGuestInvitation = {
      ...this.editGuestInvitation,
      data: JSON.stringify(data)
    }
  }

  save = (data: any) => {
    if (this.editGuestInvitation?.id) {
      if (data.guestNames) data.guestNames = data.guestNames.filter((_: string) => _);
      this.editGuestInvitation!.data = JSON.stringify(data);
      this.guests$ = this.guestInvitationService.update(this.editGuestInvitation.id, this.editGuestInvitation)
        .pipe(
          switchMap(() => {
            const pageNumber = this.table.first! / this.table.rows!;
            const globalFilter: any = this.table?.filters['global'] || '';
            return this.loadGuests(pageNumber, this.table.rows!, globalFilter['value'] || '', this.table?.sortField || '', this.table.sortOrder == 1 ? 'Ascending' : 'Descending');
          })
        );
    }

    this.editGuestInvitation = undefined;
    this.showEditGuestInvitationModal = false;
  }

  customTrackBy(index: number, obj: any): any {
    return index;
  }

  delete = async (guestInvitation: GuestInvitation) => {
    if (guestInvitation.data) {
      this.confirmationService.confirm({
        message: `This guest has already responded. Are you sure you want to delete it and all related records? This is irreversible!`,
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: async () => {
          this.guests$ = this.guestInvitationService.delete(guestInvitation.id!)
            .pipe(
              switchMap(() => {
                const pageNumber = this.table.first! / this.table.rows!;
                const globalFilter: any = this.table?.filters['global'] || '';
                return this.loadGuests(pageNumber, this.table.rows!, globalFilter['value'] || '', this.table?.sortField || '', this.table.sortOrder == 1 ? 'Ascending' : 'Descending');
              })
            );
        }
      });
    }
    else {
      this.guests$ = this.guestInvitationService.delete(guestInvitation.id!)
        .pipe(
          switchMap(() => {
            const pageNumber = this.table.first! / this.table.rows!;
            const globalFilter: any = this.table?.filters['global'] || '';
            return this.loadGuests(pageNumber, this.table.rows!, globalFilter['value'] || '', this.table?.sortField || '', this.table.sortOrder == 1 ? 'Ascending' : 'Descending');
          })
        );
    }
  }

  onSearch = (event: any) => {
    this.table.filterGlobal(event.target!.value, 'contains');
  }

  copyLink = (code: string) => {
    let url = `${location.protocol}//${location.host}`;
    if (!url.includes('localhost'))
      url += '/client';

    url += `/invitation/${code}`;

    navigator.clipboard.writeText(url);
    this.messageService.add({ severity: "info", summary: "Success", detail: "Link copied!" });
  }
}
