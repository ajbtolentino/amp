import { Component, Renderer2 } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RsvpService } from '@core/services';
import { GuestInvitationService } from '@modules/event';
import { GuestInvitation } from '@shared/models';
import { catchError, Observable, switchMap, throwError } from 'rxjs';

import { gsap } from "gsap";
import { ScrollTrigger } from "gsap/ScrollTrigger";

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<GuestInvitation> = new Observable<GuestInvitation>();
  unlistener: () => void;

  constructor(private guestInvitationService: GuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute,
    private router: Router,
    private renderer2: Renderer2) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code)
      this.guestInvitation$ = this.guestInvitationService.rsvp(code)
        .pipe(
          catchError(error => {
            this.router.navigate(['error'])
            return throwError(() => error);
          })
        )

    this.unlistener = this.renderer2.listen("document", "load", event => {
      console.log(`I am detecting img load`);
    });
  }

  ngOnInit(): void {
    gsap.registerPlugin(ScrollTrigger);
  }

  refresh(): void {
    ScrollTrigger.refresh();
  }

  initScrollTrigger(): void {
    document.querySelectorAll("img[loading='lazy']").forEach(e => {
      const observer = new ResizeObserver(entries => {
        this.refresh();
      });

      observer.observe(e);
    });

    let centerOffset = 0;

    if (window.innerWidth < 405) {
      centerOffset = 50;
    }

    if (window.innerHeight > 400) {
      let cards: any[] = gsap.utils.toArray(".stack-card");

      let stickDistance = 50;

      let lastCardST = ScrollTrigger.create({
        trigger: cards[cards.length - 1],
        start: "center center",
      });

      cards.forEach((card, index) => {
        var scale = 1 - (cards.length - index) * 0.025;
        let scaleDown = gsap.to(card,
          {
            scale: scale,
            ease: 'power1.in',
            rotate: index + 1 !== cards.length ? -5 + ((index + 1) * 5) : 0,
            // top: 0
          });

        ScrollTrigger.create({
          trigger: card,
          start: "center center",
          end: () => lastCardST.start + stickDistance,
          pin: true,
          markers: false,
          pinSpacing: false,
          scrub: true,
          animation: scaleDown,
          toggleActions: "restart none none reverse"
        });
      });
    }
  }

  onSubmit = async (event: { guestInvitationId: string, data: any }) => {
    const code = this.route.snapshot.paramMap.get("code");
    this.guestInvitation$ = this.rsvpService.update(event.guestInvitationId, JSON.stringify(event.data))
      .pipe(
        switchMap(() => this.guestInvitationService.rsvp(code!))
      )
  }
}
