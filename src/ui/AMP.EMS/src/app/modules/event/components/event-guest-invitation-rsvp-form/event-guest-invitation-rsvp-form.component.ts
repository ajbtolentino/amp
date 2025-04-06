import { animate, AUTO_STYLE, state, style, transition, trigger } from '@angular/animations';
import { AfterViewInit, Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { GuestInvitationRsvp } from '@shared/models';
import { OnDynamicData, OnDynamicMount } from 'ngx-dynamic-hooks';

@Component({
  selector: 'app-event-guest-invitation-rsvp-label',
  template: `{{text}}`
})
export class EventGuestInvitationRSVPLabelComponent {
  @Input() text?: string | undefined | null | '';
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-changeable-label',
  template: `
  <span *ngIf="isLabelShown" (click)="toggleLabel()">
    {{text}}
</span>
<p-dropdown *ngIf="!isLabelShown" [options]="options!">
</p-dropdown>`
})
export class EventGuestInvitationRSVPChangeableLabelComponent {
  @Input() text?: string | undefined | null | '';
  @Input() options!: string[];
  isLabelShown: boolean = true;

  toggleLabel = () => {
    this.isLabelShown = !this.isLabelShown;
  }
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-pluralize-label',
  template: `{{value === 0 || value > 1 ? plural : singular }}`
})
export class EventGuestInvitationRSVPPluralizeLabelComponent {
  @Input() singular?: string | undefined | null | '';
  @Input() plural?: string | undefined | null | '';
  @Input() value: number = 0;
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-change-response-form',
  template: `<div>
    {{text}}
  </div>`
})
export class EventGuestInvitationRSVPChangeResponseFormComponent {
  @Input() text?: string | undefined | null | '';
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-date',
  template: `
  <ng-container *ngIf="dateFormat">
    {{date | date : dateFormat }}
  </ng-container>
  <ng-container  *ngIf="!dateFormat">
    {{date | date}}
  </ng-container>
  `
})
export class EventGuestInvitationRSVPDateComponent {
  @Input() date?: string | undefined | null | '';
  @Input() dateFormat?: string | undefined | null | '';
}

declare global {
  interface Window {
    onYouTubeIframeAPIReady: () => void;
    YT: any;
  }
}

@Component({
  selector: 'app-event-guest-invitation-yt-player',
  styles: `
  `,
  template: `<div [id]="id"></div>`
})
export class EventGuestInvitationYTPlayerComponent implements OnInit, AfterViewInit, OnDestroy {
  @Input() id: string = "youtubePlayer";
  @Input() class?: string | undefined | null | '';
  @Input() title?: string | undefined | null | '';
  @Input() width?: number | undefined | null | '';
  @Input() height?: number | undefined | null | '';
  @Input() frameborder?: number | undefined | null | '';
  @Input() allow?: string | undefined | null | '';
  @Input() src: string = "";
  @Input() videoId: string = "";
  @Input() volume?: number = 50;
  @Input() referrerpolicy?: string | undefined | null | '';
  @Input() autoplay?: number = 0;
  player: any;
  youtubeUrl: SafeResourceUrl | undefined;
  intersectionObserver!: IntersectionObserver;

  constructor(private sanitizer: DomSanitizer) {

  }

  ngOnInit(): void {
    this.youtubeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.src || '');
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      // Load YouTube API
      if (!document.getElementById("iframe-api")) {
        const tag = document.createElement('script');
        tag.id = "iframe-api"
        tag.src = 'https://www.youtube.com/iframe_api';
        document.body.appendChild(tag);
      }

      if (!window.onYouTubeIframeAPIReady) {
        window.onYouTubeIframeAPIReady = () => {
          this.createPlayer();
        };
      }

      if ((window as any).YT && (window as any).YT.Player) {
        this.createPlayer();
      }
    }, 200);
  }

  createPlayer(): void {
    this.player = new window.YT.Player(this.id, {
      videoId: this.videoId,
      playerVars: {
        autoplay: this.autoplay,
        mute: 1,
        rel: 0,
        playsinline: 1,
      },
      events: {
        'onReady': (event: any) => {
          this.setupIntersectionObserver(event);
        }
      }
    });
  }

  setupIntersectionObserver(event: any): void {
    // Set up Intersection Observer to detect visibility of the player
    this.intersectionObserver = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          // Play the video if visible
          if (this.player && this.player.getPlayerState !== 1) {
            this.player.setVolume(50);
            this.player.unMute();
            this.player.playVideo();
          }
        }
        else {
          if (this.player) {
            this.player.pauseVideo();
          }
        }
      });
    }, {
      threshold: 0.5 // Trigger the observer when 50% of the element is visible
    });

    // Observe the YouTube player container
    const youtubePlayerElement = document.getElementById(this.id);

    if (youtubePlayerElement)
      this.intersectionObserver.observe(youtubePlayerElement);
  }

  ngOnDestroy() {
    if (this.intersectionObserver) {
      this.intersectionObserver.disconnect();
    }
    if (this.player && this.player.destroy) {
      this.player.destroy();
    }
  }
}

const DEFAULT_DURATION = 300;

@Component({
  selector: 'app-event-guest-invitation-rsvp-form',
  templateUrl: './event-guest-invitation-rsvp-form.component.html',
  styles: `
  .guest-names-container {
    overflow: hidden;
  }
  `,
  animations: [
    trigger('collapse', [
      state('false', style({ height: AUTO_STYLE, visibility: AUTO_STYLE })),
      state('true', style({ height: '0', visibility: 'hidden' })),
      transition('false => true', animate(DEFAULT_DURATION + 'ms ease-in')),
      transition('true => false', animate(DEFAULT_DURATION + 'ms ease-out'))
    ])
  ]
})
export class EventGuestInvitationRSVPFormComponent implements OnInit, OnDynamicMount {
  @Input() choiceMessage?: string;
  @Input() acceptMessage?: string;
  @Input() requestDetailsMessage?: string;
  @Input() requestDetails?: boolean;
  @Input() showGuestInput?: boolean;

  @Input() secondaryGuestsLabel?: string;
  @Input() secondaryGuestsPlaceholder?: string;

  @Input() checkIfResponded?: boolean;
  @Input() checkIfRespondedMessage?: string;
  @Input() checkIfAcceptedMessage?: string;
  @Input() checkIfDeclinedMessage?: string;
  @Input() changeResponseButtonLabel?: string;

  @Input() acceptLabel: string = 'Accept';
  @Input() declineLabel: string = 'Decline';
  @Input() submitButtonClass: string = "";
  @Output() onResponseChange: EventEmitter<any> = new EventEmitter();
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  showRsvpForm: boolean = false;

  guestInvitationId: string = '';
  guestInvitationRsvp: GuestInvitationRsvp = { guestNames: [] };

  rsvpForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.rsvpForm! = this.formBuilder.group({
      guestNames: this.formBuilder.array([]),
      details: [''],
      response: ['']
    });
  }

  get guestNames(): FormArray<FormControl> {
    return this.rsvpForm.get('guestNames') as FormArray<FormControl>;
  }

  changeResponse = () => {
    this.guestInvitationRsvp.response = undefined;
  }

  onDynamicMount(data: OnDynamicData): void {
    const length = data.context.guestInvitation.seats || 0;

    this.showRsvpForm = data.context.guestInvitation.invitation.rsvpDeadline && new Date() <= new Date(data.context.guestInvitation.invitation.rsvpDeadline);
    this.guestInvitationId = data.context.guestInvitation.id;
    this.guestInvitationRsvp = data.context.guestInvitation.data ?
      JSON.parse(data.context.guestInvitation.data) :
      {};

    if (data.context.guestInvitation.invitation.rsvpDeadline)
      data.context.guestInvitation.invitation.rsvpDeadline = new Date(data.context.guestInvitation.invitation.rsvpDeadline);

    for (let i = 0; i < length - 1; i++) {
      const name = this.guestInvitationRsvp.guestNames && this.guestInvitationRsvp.guestNames ? this.guestInvitationRsvp.guestNames[i] : null;
      const guestNameControl = new FormControl(name);
      this.guestNames.push(guestNameControl);
    }

    this.rsvpForm.patchValue({ response: this.guestInvitationRsvp.response });
  }

  onSendResponseClick() {
    if (this.rsvpForm.valid) {
      this.guestInvitationRsvp.guestNames = this.rsvpForm.value['guestNames']?.filter((_: any) => _);
      this.guestInvitationRsvp.response = this.rsvpForm.value['response'];
      this.guestInvitationRsvp.details = this.rsvpForm.value['details'];
      this.onSubmit.emit({ guestInvitationId: this.guestInvitationId, data: this.guestInvitationRsvp });
      this.rsvpForm.reset();
    } else {
      this.rsvpForm.markAllAsTouched();
    }
  }
}