import { Component, OnInit } from '@angular/core';
import { InvitationService } from '../../../core/services/event-invitation.service';
import { Invitation } from '../../../core/models/invitation';
import { ActivatedRoute, Router } from '@angular/router';
import { Rsvp } from '../../../core/models/rsvp';
import { RsvpService } from '../../../core/services/rsvp.service';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent implements OnInit {
  invitation: Invitation | undefined;

  rsvp: Rsvp = {};

  response: string | undefined;

  showDetails: boolean = false;

  constructor(private invitationService: InvitationService,
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
    const response = await this.invitationService.rsvp(code);

    if (response) {
      this.invitation = response.data;
      this.rsvp.invitationId = this.invitation?.id;
      this.showDetails = !this.invitation?.limitedView;
    }
  }
}
