import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RsvpService } from '@core/services';
import { ContentService } from '@core/services/content.service';
import { EventGuestInvitationService, EventGuestService, GuestService } from '@modules/event/guest';
import { EventInvitationService } from '@modules/event/invitation';
import { EventGuestInvitation, EventGuestInvitationRsvp, Guest } from '@shared/models';
import { Content } from '@shared/models/content.model';
import { lastValueFrom, Observable, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  eventGuestInvitation$: Observable<EventGuestInvitation> = new Observable<EventGuestInvitation>();
  content$: Observable<Content> = new Observable<Content>();
  guest$: Observable<Guest> = new Observable<Guest>();

  constructor(private eventGuestInvitationService: EventGuestInvitationService,
    private eventInvitation: EventInvitationService,
    private eventGuestService: EventGuestService,
    private guestService: GuestService,
    private contentService: ContentService,
    private rsvpService: RsvpService, private route: ActivatedRoute) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code) this.eventGuestInvitation$ = this.eventGuestInvitationService.rsvp(code)
      .pipe(
        tap(eventGuestInvitation => {
          this.content$ = this.eventInvitation.get(eventGuestInvitation.eventInvitationId!)
            .pipe(
              switchMap(eventInvitation => this.contentService.get(eventInvitation.contentId!)),
              tap(eventInvitation => {
                eventGuestInvitation.eventInvitation = eventInvitation;
              }));
          this.guest$ = this.eventGuestService.get(eventGuestInvitation.eventGuestId!)
            .pipe(switchMap(eventGuest => this.guestService.get(eventGuest.guestId!)));
        })
      );
  }

  onSubmit = async (rsvp: EventGuestInvitationRsvp) => {
    await lastValueFrom(this.rsvpService.add(rsvp));
  }
}
