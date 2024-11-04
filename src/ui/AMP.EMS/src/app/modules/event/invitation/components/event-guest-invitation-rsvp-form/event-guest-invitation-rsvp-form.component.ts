import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, FormControl } from '@angular/forms';
import { Guest, EventGuestInvitationRsvp } from '@shared/models';
import { OnDynamicData, OnDynamicMount } from 'ngx-dynamic-hooks';

@Component({
  selector: 'app-event-guest-invitation-rsvp-label',
  template: `{{text}}`
})
export class EventGuestInvitationRSVPLabelComponent {
  @Input() text?: string | '';
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-form',
  templateUrl: './event-guest-invitation-rsvp-form.component.html'
})
export class EventGuestInvitationRSVPFormComponent implements OnInit, OnDynamicMount {
  @Input() choiceMessage?: string;
  @Input() acceptMessage?: string;

  @Input() guest!: Guest;
  @Input() acceptLabel: string = 'Accept';
  @Input() declineLabel: string = 'Decline';
  @Input() submitButtonClass: string = "";
  @Output() onResponseChange: EventEmitter<any> = new EventEmitter();
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  eventGuestInvitationRsvp: EventGuestInvitationRsvp = { guestNames: [] };

  rsvpForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.rsvpForm! = this.formBuilder.group({
      guestNames: this.formBuilder.array([]),
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
    const length = data.context.eventGuestInvitation.maxGuests || 0;

    console.log(length)

    this.eventGuestInvitationRsvp.eventGuestInvitationId = data.context.eventGuestInvitation.id;

    for (let i = 0; i < length; i++) {
      // this.eventGuestInvitationRsvp.guestNames?.push('');
      const guestNameControl = new FormControl(null);
      this.guestNames.push(guestNameControl);
    }
  }

  onSendResponseClick() {
    if (this.rsvpForm.valid) {
      this.eventGuestInvitationRsvp.guestNames = this.rsvpForm.value['guestNames'];
      this.eventGuestInvitationRsvp.response = this.rsvpForm.value['response'];
      this.onSubmit.emit(this.eventGuestInvitationRsvp);
    } else {
      this.rsvpForm.markAllAsTouched();
    }
  }
}