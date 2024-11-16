import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RsvpService } from '@core/services';
import { GuestInvitationService } from '@modules/event';
import { GuestInvitation, GuestInvitationRsvp } from '@shared/models';
import { lastValueFrom, Observable } from 'rxjs';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<GuestInvitation> = new Observable<GuestInvitation>();

  constructor(private guestInvitationService: GuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code) this.guestInvitation$ = this.guestInvitationService.rsvp(code)
  }

  onSubmit = async (rsvp: GuestInvitationRsvp) => {
    await lastValueFrom(this.rsvpService.add(rsvp));
  }
}
