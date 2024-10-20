import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventGuestInvitationRSVP } from '../../../core/models/event-guest-invitation-rsvp';
import { RsvpService } from '../../../core/services/rsvp.service';
import { EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  eventGuestInvitation: EventGuestInvitation | undefined;

  constructor(private eventGuestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(data => {
      const code = data.get("code");

      if (code) {
        this.loadInvitation(code);
      }
    });
  }

  loadInvitation = async (code: string) => {
    const response = await this.eventGuestInvitationService.rsvp(code);

    if (response) {
      this.eventGuestInvitation = response.data;
    }
  }

  onSubmit = async (rsvp: EventGuestInvitationRSVP) => {
    rsvp.eventGuestInvitationId = this.eventGuestInvitation?.id;
    await this.rsvpService.add(rsvp);
  }
}
