import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
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

@Component({
  selector: 'app-event-guest-invitation-rsvp-form',
  templateUrl: './event-guest-invitation-rsvp-form.component.html'
})
export class EventGuestInvitationRSVPFormComponent implements OnInit, OnDynamicMount {
  @Input() choiceMessage?: string;
  @Input() acceptMessage?: string;
  @Input() requestDetailsMessage?: string;
  @Input() requestDetails?: boolean;

  @Input() secondaryGuestsLabel?: string;
  @Input() secondaryGuestsPlaceholder?: string;

  @Input() checkIfResponded?: boolean;
  @Input() checkIfRespondedMessage?: string;
  @Input() checkIfAcceptedMessage?: string;
  @Input() checkIfDeclinedMessage?: string;

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