import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
  @Input() guest!: Guest;
  @Input() acceptLabel: string = 'Accept';
  @Input() declineLabel: string = 'Decline';
  @Input() submitButtonClass: string = "";
  @Output() onResponseChange: EventEmitter<any> = new EventEmitter();
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  eventGuestInvitationRsvp: EventGuestInvitationRsvp = { guestNames: [] };

  ngOnInit(): void {

  }

  onDynamicMount(data: OnDynamicData): void {
    const length = data.context.eventGuestInvitation.maxGuests || 0;

    this.eventGuestInvitationRsvp.eventGuestInvitationId = data.context.eventGuestInvitation.id;
    this.eventGuestInvitationRsvp.response = "ACCEPT";

    for (let i = 0; i < length; i++) {
      this.eventGuestInvitationRsvp.guestNames?.push('');
    }
  }

  onSendResponseClick() {
    this.onSubmit.emit(this.eventGuestInvitationRsvp);
  }
}