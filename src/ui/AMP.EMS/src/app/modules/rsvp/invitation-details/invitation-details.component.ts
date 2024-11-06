import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventGuestInvitationService } from '@modules/event/guest';
import { EventGuestInvitation, EventGuestInvitationRsvp } from '@shared/models';
import { lastValueFrom, Observable } from 'rxjs';
import { RsvpService } from '../../../core/services/rsvp.service';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  eventGuestInvitation$: Observable<EventGuestInvitation> = new Observable<EventGuestInvitation>();

  constructor(private eventGuestInvitationService: EventGuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(data => {
      const code = data.get("code");

      if (code) this.eventGuestInvitation$ = this.eventGuestInvitationService.rsvp(code);
    });
  }

  onSubmit = async (rsvp: EventGuestInvitationRsvp) => {
    await lastValueFrom(this.rsvpService.add(rsvp));
  }
}
