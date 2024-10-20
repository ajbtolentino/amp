import { Component, OnInit } from '@angular/core';
import { EventGuest } from '../../../core/models/event-guest';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventGuestService } from '../../../core/services/event-guest.service';
import { EventRoleService } from '../../../core/services/event-role.service';
import { EventRole } from '../../../core/models/event-role';
import { EventService } from '../../../core/services/event.service';
import { EventInvitationService } from '../../../core/services/event-invitation.service';
import { EventInvitation } from '../../../core/models/event-invitation';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html',
  styles: ``
})
export class EventGuestDetailsComponent implements OnInit {
  eventId!: string;

  eventGuest: EventGuest = {
    guest: { firstName: '', lastName: '', nickName: '', phoneNumber: '' },
    event: {},
    eventGuestInvitations: [],
    eventGuestRoles: []
  };

  loading: boolean = false;

  eventRoles: EventRole[] = [];
  eventInvitations: EventInvitation[] = [];

  selectedEventRoles: string[] = [];
  selectedEventInvitations: string[] = [];

  constructor(private eventService: EventService,
    private eventGuestService: EventGuestService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.eventGuest.eventId = this.eventId;
        if (this.eventId) this.loadArray();
      }
    });

    this.route.paramMap.subscribe(data => {
      const eventGuestId = data.get("eventGuestId");

      if (eventGuestId) this.loadEventGuest(eventGuestId);
    });
  }

  loadArray = async () => {
    this.loading = true;

    var eventRoleResponse = await this.eventService.getRoles(this.eventId);
    if (eventRoleResponse?.data) this.eventRoles = eventRoleResponse.data;

    var eventInvitationResponse = await this.eventService.getInvitations(this.eventId);
    if (eventInvitationResponse?.data) this.eventInvitations = eventInvitationResponse.data;

    this.loading = false;
  }

  loadEventGuest = async (eventGuestId: string) => {
    this.loading = true;

    var response = await this.eventGuestService.get(eventGuestId);
    if (response?.data) {
      this.eventGuest = response.data;
      this.selectedEventRoles = this.eventGuest.eventGuestRoles?.map(_ => _.eventRoleId || '') || [];
      this.selectedEventInvitations = this.eventGuest.eventGuestInvitations?.map<string>(_ => _.eventInvitationId || '') || [];
    }

    this.loading = false;
  }

  save = async () => {
    this.loading = true;

    if (this.eventGuest.guest?.firstName?.trim() && this.eventGuest?.guest?.lastName?.trim()) {

      if (this.eventGuest.id) {
        await this.eventGuestService.update(this.eventGuest, this.selectedEventRoles, this.selectedEventInvitations);
      }
      else {
        await this.eventGuestService.add(this.eventGuest, this.selectedEventRoles, this.selectedEventInvitations);
      }
    }

    this.loading = false;

    this.router.navigate([`/event/${this.eventId}/guests`]);
  }
}
