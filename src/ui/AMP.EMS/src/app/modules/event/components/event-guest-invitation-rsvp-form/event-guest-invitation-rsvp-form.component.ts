import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  selector: 'app-event-guest-invitation-rsvp-pluralize-label',
  template: `{{value === 0 || value > 1 ? plural : singular }}`
})
export class EventGuestInvitationRSVPPluralizeLabelComponent {
  @Input() singular?: string | undefined | null | '';
  @Input() plural?: string | undefined | null | '';
  @Input() value: number = 0;
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

  @Input() acceptLabel: string = 'Accept';
  @Input() declineLabel: string = 'Decline';
  @Input() submitButtonClass: string = "";
  @Output() onResponseChange: EventEmitter<any> = new EventEmitter();
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  guestInvitationRsvp: GuestInvitationRsvp = { guestNames: [] };

  rsvpForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.rsvpForm! = this.formBuilder.group({
      guestNames: this.formBuilder.array([]),
      details: [''],
      response: ['', [Validators.required]]
    });

    this.rsvpForm.get('response')?.valueChanges.subscribe(response => {
      const guestNameControl = this.guestNames.at(0);

      if (response === 'ACCEPT') {
        this.guestNames.at(0)?.setValidators(Validators.required);
      }
      else {
        this.guestNames.at(0)?.clearValidators();
      }
    });
  }

  get guestNames(): FormArray<FormControl> {
    return this.rsvpForm.get('guestNames') as FormArray<FormControl>;
  }

  onDynamicMount(data: OnDynamicData): void {
    const length = data.context.guestInvitation.seats || 0;

    this.guestInvitationRsvp.guestInvitationId = data.context.guestInvitation.id;

    if (data.context.guestInvitation.invitation.rsvpDeadline)
      data.context.guestInvitation.invitation.rsvpDeadline = new Date(data.context.guestInvitation.invitation.rsvpDeadline);

    for (let i = 0; i < length; i++) {
      const guestNameControl = new FormControl(null);
      this.guestNames.push(guestNameControl);
    }
  }

  onSendResponseClick() {
    if (this.rsvpForm.valid) {
      this.guestInvitationRsvp.guestNames = this.rsvpForm.value['guestNames'];
      this.guestInvitationRsvp.response = this.rsvpForm.value['response'];
      this.guestInvitationRsvp.data = this.rsvpForm.value['details'];
      this.onSubmit.emit(this.guestInvitationRsvp);
      this.rsvpForm.reset();
    } else {
      this.rsvpForm.markAllAsTouched();
    }
  }
}