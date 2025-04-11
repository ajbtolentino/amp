import { Component, Renderer2 } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { RsvpService } from '@core/services';
import { GuestInvitationService } from '@modules/event';
import { GuestInvitation } from '@shared/models';
import { gsap } from "gsap";
import { ScrollTrigger } from "gsap/ScrollTrigger";
import { catchError, Observable, switchMap, tap, throwError } from 'rxjs';

@Component({
  selector: 'app-invitation-details',
  templateUrl: './invitation-details.component.html',
  styleUrl: './invitation-details.component.scss'
})
export class InvitationDetailsComponent {
  guestInvitation$: Observable<GuestInvitation> = new Observable<GuestInvitation>();

  constructor(private guestInvitationService: GuestInvitationService,
    private rsvpService: RsvpService, private route: ActivatedRoute,
    private router: Router,
    private renderer2: Renderer2,
    private titleService: Title) {
    const code = this.route.snapshot.paramMap.get("code");
    if (code)
      this.guestInvitation$ = this.guestInvitationService.rsvp(code)
        .pipe(
          tap((e: GuestInvitation) => {
            this.titleService.setTitle(`Invitation - ${e.guest?.firstName} ${e.guest?.lastName}`)
          }),
          catchError(error => {
            this.router.navigate(['error'])
            return throwError(() => error);
          })
        )
  }

  ngOnInit(): void {
    gsap.registerPlugin(ScrollTrigger);
    // const lenis = new Lenis();

    // Synchronize Lenis scrolling with GSAP's ScrollTrigger plugin
    // lenis.on('scroll', ScrollTrigger.update);

    // // Add Lenis's requestAnimationFrame (raf) method to GSAP's ticker
    // // This ensures Lenis's smooth scroll animation updates on each GSAP tick
    // gsap.ticker.add((time) => {
    //   lenis.raf(time * 1000); // Convert time from seconds to milliseconds
    // });

    // // Disable lag smoothing in GSAP to prevent any delay in scroll animations
    // gsap.ticker.lagSmoothing(0);
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

    window.addEventListener('resize', () => {
      ScrollTrigger.refresh();
    });

    const cards: any[] = gsap.utils.toArray(".sticky-card");
    const rotations: any[] = [-10, 10, 0];

    const tl = gsap.timeline(
      {
        scrollTrigger:
        {
          trigger: '.sticky-cards',
          start: "top top",
          end: `+=${window.innerHeight}px`,
          pin: true,
          pinSpacing: true,
          markers: false,
          scrub: 1,
          onUpdate: (self) => {
            const progress = self.progress;
            const totalCards = cards.length;
            const progressPerCard = 1 / totalCards;

            cards.forEach((card, index) => {
              const cardStart = index * progressPerCard;
              let cardProgress = (progress - cardStart) / progressPerCard;
              cardProgress = Math.min(Math.max(cardProgress, 0), 1);

              let yPosition = (window.innerHeight * 2) * (1 - cardProgress);
              let xPosition = 0;

              if (cardProgress === 1 && index < totalCards - 1) {
                const remainingProgress = (progress - (cardStart + progressPerCard)) / (1 - (cardStart + progressPerCard));

                if (remainingProgress > 0) {
                  const distanceMultiplier = 1 - index * 0.05;
                  xPosition = -window.innerWidth * 0.3 * ((distanceMultiplier * .75) * (index % 2 ? -1 : 1)) * remainingProgress;
                  yPosition = -window.innerHeight * 0.3 * (distanceMultiplier * 0.05) * remainingProgress;
                }
              }

              const currentRotate = cardProgress === 1 ? self.progress * rotations[index] : 0;

              gsap.to(card,
                {
                  y: yPosition,
                  x: xPosition,
                  duration: 0,
                  ease: "none"
                });

              gsap.to(card,
                {
                  rotate: currentRotate,
                  duration: .25,
                  ease: "none"
                });
            });
          }
        }
      });

    tl.to('.sticky-cards', {
      backgroundColor: document.getElementsByClassName('sticky-cards')[0].getAttribute('data-to-color') ?? ''
    });
  }

  onSubmit = async (event: { guestInvitationId: string, data: any }) => {
    const code = this.route.snapshot.paramMap.get("code");
    this.guestInvitation$ = this.rsvpService.update(event.guestInvitationId, JSON.stringify(event.data))
      .pipe(
        switchMap(() => this.guestInvitationService.rsvp(code!))
      )
  }
}
