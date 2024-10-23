import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { EventGuestInvitationRSVP } from '../../../core/models/event-guest-invitation-rsvp';
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
  template: `
    <ng-content></ng-content>

    <div class="form-container">
      <div class="guest-names-container">
        <input class="w-full" pInputText type="text" placeholder='Guest Name' *ngFor="let n of eventGuestInvitationRSVP.eventGuestInvitationRSVPItems; let index=index" [(ngModel)]="eventGuestInvitationRSVP!.eventGuestInvitationRSVPItems![index].name"/>
      </div>
      <div class="radiobutton-container">
          <div>
            <label for="accept" class="accept-label">{{acceptLabel}}</label>
            <input id="accept" type="radio" [(ngModel)]="eventGuestInvitationRSVP.response" value="ACCEPT"/>
            <!-- <p-radioButton name="accept" [(ngModel)]="eventGuestInvitationRSVP.response" value="ACCEPT">Accept</p-radioButton> -->
          </div>
          <div>
            <label for="decline" class="decline-label">{{declineLabel}}</label>
            <input id="decline" type="radio" [(ngModel)]="eventGuestInvitationRSVP.response" value="DECLINE" />
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
  @Input() eventGuestInvitation!: EventGuestInvitation;
  @Input() acceptLabel: string = 'Accept';
  @Input() declineLabel: string = 'Decline';
  @Input() submitButtonClass: string = "";
  @Output() onResponseChange: EventEmitter<any> = new EventEmitter();
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  eventGuestInvitationRSVP: EventGuestInvitationRSVP = { eventGuestInvitationRSVPItems: [] };

  ngOnInit(): void {

  }

  onDynamicMount(data: OnDynamicData): void {
    const length = data.context.eventGuestInvitation.eventGuest.maxGuests || 0;

    this.eventGuestInvitationRSVP.response = "ACCEPT";

    for (let i = 0; i < length; i++) {
      this.eventGuestInvitationRSVP.eventGuestInvitationRSVPItems?.push({});
    }
  }

  onSendResponseClick() {
    this.onSubmit.emit(this.eventGuestInvitationRSVP);
  }
}