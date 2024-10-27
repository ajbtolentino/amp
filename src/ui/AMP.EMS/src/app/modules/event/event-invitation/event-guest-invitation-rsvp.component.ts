import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { EventGuestInvitationRsvp } from '../../../core/models/event-guest-invitation-rsvp';
import { OnDynamicData, OnDynamicMount } from 'ngx-dynamic-hooks';
import { Guest } from '../../../core/models/guest';

@Component({
  selector: 'app-event-guest-invitation-rsvp-label',
  template: `{{text}}`
})
export class EventGuestInvitationRSVPLabelComponent {
  @Input() text?: string | '';
}

@Component({
  selector: 'app-event-guest-invitation-rsvp-form',
  template: `
    <ng-content></ng-content>

    <div class="form-container">
      <div class="guest-names-container" *ngIf="eventGuestInvitationRsvp.response === 'ACCEPT'">
        @for (item of eventGuestInvitationRsvp.guestNames; track $index; let  i = $index) {    
            <input class="w-full" pInputText type="text" placeholder='Guest Name' [(ngModel)]="eventGuestInvitationRsvp!.guestNames![i]"/>
        }
      </div>
      <div class="radiobutton-container">
          <div>
            <label for="accept" class="accept-label">{{acceptLabel}}</label>
            <input id="accept" type="radio" [(ngModel)]="eventGuestInvitationRsvp.response" value="ACCEPT"/>
            <!-- <p-radioButton name="accept" [(ngModel)]="eventGuestInvitationRSVP.response" value="ACCEPT">Accept</p-radioButton> -->
          </div>
          <div>
            <label for="decline" class="decline-label">{{declineLabel}}</label>
            <input id="decline" type="radio" [(ngModel)]="eventGuestInvitationRsvp.response" value="DECLINE" />
            <!-- <p-radioButton name="decline" [(ngModel)]="eventGuestInvitationRSVP.response"  value="DECLINE">Decline</p-radioButton> -->
          </div>
      </div>
      <div class="button-container">
        <!-- <button class="submit-button" [ngClass]="submitButtonClass" (click)="onSendResponseClick()">Send Response</button> -->
        <p-button severity="info" [ngClass]="submitButtonClass" (click)="onSendResponseClick()">Send Response</p-button>
      </div>
    </div>
`
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