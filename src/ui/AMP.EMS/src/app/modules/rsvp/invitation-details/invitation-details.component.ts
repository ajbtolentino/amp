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
  }

  refresh(): void {
    ScrollTrigger.refresh();
  }

  initScrollTrigger(): void {
    window.addEventListener('resize', () => {
      ScrollTrigger.refresh();
    });

    this.loadGsap();
  }

  loadGsap(): void {
    const cards: any[] = gsap.utils.toArray(".sticky-card");
    const rotations: any[] = [0, 10, -10];

    cards.forEach((card, index) => {
      gsap.set(card, {
        rotate: 0,
        zIndex: -index,
        transformOrigin: `${index % 2 ? '0% 100%' : '100% 100%'}`
      })
    });

    const cardTimeline = gsap.timeline(
      {
        scrollTrigger:
        {
          trigger: '.sticky-cards',
          start: "top top",
          end: `+=${window.innerHeight * 2}px`,
          pin: true,
          // pinSpacing: true,
          markers: true,
          scrub: 1,
          onUpdate: (self) => {
            const progress = self.progress;
            const totalCards = cards.length;
            const progressPerCard = 1 / totalCards;

            cards.forEach((card, index) => {
              const cardStart = index * progressPerCard;
              let cardProgress = (progress - cardStart) / progressPerCard;
              cardProgress = Math.min(Math.max(cardProgress, 0), 1);

              const rect = card.getBoundingClientRect();
              const x = rect.left + window.scrollX;
              const y = rect.top + window.scrollY;

              let yPosition = 0;
              let xPosition = 0;

              if (cardProgress === 1 && index < totalCards - 1) {
                const remainingProgress = (progress - (cardStart + progressPerCard)) / (1 - (cardStart + progressPerCard));

                if (remainingProgress > 0) {
                  const distanceMultiplier = 3;
                  // xPosition = -window.innerWidth * 0.3 * ((distanceMultiplier * .75) * (index % 2 ? -1 : 1)) * remainingProgress;
                  yPosition = -window.innerHeight * distanceMultiplier * remainingProgress;
                }
              }

              gsap.to(card,
                {
                  y: yPosition,
                  duration: 0,
                  ease: "none"
                });
            });
          }
        }
      });

    cards.forEach((card, index) => {
      cardTimeline.from(cards[index], {
        rotate: rotations[index],
        x: index > 0 ? `${index % 2 ? '+=100' : '-=100'}` : card.xPosition
      })
        .to(cards[index], {
          rotate: 0,
          ease: 'elastic.in',
          duration: 0.1
        });
    });

    const changeColorCollection: any[] = gsap.utils.toArray('.change-color');

    const changeColorTL = gsap.timeline(
      {
        scrollTrigger:
        {
          trigger: '.change-color',
          start: "top center+=100",
          end: `bottom bottom`,
          markers: false,
          scrub: 1
        }
      });

    changeColorCollection.forEach((item, index) => {
      changeColorTL.to(item, {
        backgroundColor: item.getAttribute('data-bg-color'),
        ease: 'power1',
        duration: 1
      });

      changeColorTL.to(item, {
        color: item.getAttribute('data-color'),
        ease: 'none',
        opacity: 1,
      });
    });

    const appearBelowCollection: any[] = gsap.utils.toArray('.appear-below');

    const appearBelowTL = gsap.timeline(
      {
        scrollTrigger:
        {
          trigger: '.appear-below',
          start: "top center+=100",
          end: `bottom bottom`,
          markers: false,
          scrub: 1
        }
      });

    appearBelowCollection.forEach((item, index) => {
      appearBelowTL.fromTo(item, {
        opacity: 0,
        y: '+=10',
        ease: 'none'
      }, {
        opacity: 1,
        y: 0,
        ease: 'none',
        duration: 1
      });
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
