import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InvitationService } from '../../core/services/invitation.service';
import { Invitation } from '../../core/models/invitation';
import { ActivatedRoute } from '@angular/router';
import { Rsvp } from '../../core/models/rsvp';
import { RsvpService } from '../../core/services/rsvp.service';

@Component({
  standalone: true,
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss',
  imports: [CardModule, ButtonModule, RadioButtonModule, CommonModule, FormsModule]
})
export class InvitationDetailsComponent implements OnInit {
  invitation: Invitation | undefined;

  rsvp: Rsvp = {};

  response: string | undefined;

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
      this.rsvp.phoneNumber = "123";
    }
  }
}
