import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RsvpService } from '@core/services';
import { ContentService } from '@core/services/content.service';
import { GuestInvitationService, GuestService } from '@modules/event/guest';
import { EventInvitationService } from '@modules/event/invitation';
import { GuestInvitation, GuestInvitationRsvp, Invitation } from '@shared/models';
import { lastValueFrom, map, Observable, switchMap } from 'rxjs';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<GuestInvitation> = new Observable<GuestInvitation>();

  constructor(private eventGuestInvitationService: GuestInvitationService,
    private eventInvitation: EventInvitationService,
    private guestService: GuestService,
    private contentService: ContentService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code) this.guestInvitation$ = this.eventGuestInvitationService.rsvp(code)
      .pipe(
        switchMap(guestInvitation => this.loadInvitation(guestInvitation)),
        switchMap(guestInvitation => this.loadGuest(guestInvitation)),
      );
  }

  loadInvitation = (guestInvitation: GuestInvitation): Observable<GuestInvitation> => {
    return this.eventInvitation.get(guestInvitation.invitationId!)
      .pipe(
        switchMap(invitation => this.loadContent(invitation)),
        map(invitation => ({
          ...guestInvitation,
          invitation: invitation
        }))
      );
  }

  loadContent = (invitation: Invitation): Observable<Invitation> => {
    return this.contentService.get(invitation.contentId!)
      .pipe(
        map(content => ({
          ...invitation,
          content: content
        }))
      );
  };

  loadGuest = (guestInvitation: GuestInvitation): Observable<GuestInvitation> => {
    return this.guestService.get(guestInvitation.guestId!)
      .pipe(
        map(guest => ({
          ...guestInvitation,
          guest: guest
        }))
      );
  }

  onSubmit = async (rsvp: GuestInvitationRsvp) => {
    await lastValueFrom(this.rsvpService.add(rsvp));
  }
}
