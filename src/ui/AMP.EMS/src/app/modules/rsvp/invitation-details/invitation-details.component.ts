import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RsvpService } from '@core/services';
import { GuestInvitationService } from '@modules/event';
import { GuestInvitation } from '@shared/models';
import { catchError, Observable, switchMap, throwError } from 'rxjs';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<GuestInvitation> = new Observable<GuestInvitation>();

  constructor(private guestInvitationService: GuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute,
    private router: Router) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code)
      this.guestInvitation$ = this.guestInvitationService.rsvp(code)
        .pipe(
          catchError(error => {
            this.router.navigate(['error'])
            return throwError(() => error);
          })
        )
  }

  onSubmit = async (event: { guestInvitationId: string, data: any }) => {
    const code = this.route.snapshot.paramMap.get("code");
    this.guestInvitation$ = this.rsvpService.update(event.guestInvitationId, JSON.stringify(event.data))
      .pipe(
        switchMap(() => this.guestInvitationService.rsvp(code!))
      )
  }
}
