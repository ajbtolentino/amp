import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Rsvp } from '../../../core/models/rsvp';
import { RsvpService } from '../../../core/services/rsvp.service';
import { EventGuestInvitationService } from '../../../core/services/event-guest-invitation.service';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent implements OnInit {
  eventGuestInvitation: EventGuestInvitation | undefined;

  rsvp: Rsvp = {};

  response: string | undefined;

  showDetails: boolean = false;

  constructor(private eventGuestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(data => {
      const code = data.get("code");

      if (code) {
        this.loadInvitation(code);
      }
    });
  }

  ngOnInit(): void {

  }

  sendResponse = async () => {
    await this.rsvpService.add(this.rsvp);
  }

  loadInvitation = async (code: string) => {
    const response = await this.eventGuestInvitationService.rsvp(code);

    if (response) {
      this.eventGuestInvitation = response.data;
      this.rsvp.invitationId = this.eventGuestInvitation?.id;
      this.showDetails = !this.eventGuestInvitation?.limitedView;
    }
  }
}
