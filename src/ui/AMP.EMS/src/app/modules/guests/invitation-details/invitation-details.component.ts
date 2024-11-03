import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom, Observable } from 'rxjs';
import { RsvpService } from '../../../core/services/rsvp.service';
import { EventGuestInvitationResponse, EventGuestInvitationService } from '@modules/event/guest';
import { EventGuestInvitationRsvp } from '@shared/models';

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
