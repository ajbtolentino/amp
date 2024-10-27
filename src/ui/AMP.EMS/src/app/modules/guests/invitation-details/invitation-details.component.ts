import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventGuestInvitationRsvp } from '../../../core/models/event-guest-invitation-rsvp';
import { GuestService } from '../../../core/services/guest.service';
import { lastValueFrom, Observable } from 'rxjs';
import { EventGuestInvitationResponse, EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';
import { RsvpService } from '../../../core/services/rsvp.service';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<EventGuestInvitationResponse> = new Observable<EventGuestInvitationResponse>();

  constructor(private guestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(data => {
      const code = data.get("code");

      if (code) this.guestInvitation$ = this.guestInvitationService.rsvp(code);
    });
  }

  onSubmit = async (rsvp: EventGuestInvitationRsvp) => {
    console.log(rsvp);
    await lastValueFrom(this.rsvpService.add(rsvp));
  }
}
