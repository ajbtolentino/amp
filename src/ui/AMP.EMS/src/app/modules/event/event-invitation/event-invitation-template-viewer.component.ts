import { AfterContentChecked, AfterContentInit, Component, ContentChild, ContentChildren, ElementRef, EventEmitter, forwardRef, Input, OnInit, Output, QueryList, ViewChild } from '@angular/core';
import { EventInvitation } from '../../../core/models/event-invitation';
import { EventGuestInvitation } from '../../../core/models/event-guest-invitation';
import { Rsvp } from '../../../core/models/rsvp';
import { RadioButton, RadioButtonModule } from 'primeng/radiobutton';
import { OnDynamicMount, OnDynamicData, DynamicContentChild } from 'ngx-dynamic-hooks';

@Component({
  selector: 'app-event-invitation-rsvp',
  template: `
  <div class="p-3">
    Hello, {{invitation.guest?.firstName}} {{invitation.guest?.lastName}}. We have reserved <u><b>{{invitation.maxGuests}}</b></u> seats for you. Please enter your names and submit by dd-mm-yyyy
  </div>

  <ng-container *ngIf="invitation.maxGuests">
    <div *ngFor="let n of [].constructor(invitation.maxGuests)">
        <input class="w-full" pInputText type="text" placeholder='Guest Name' />
    </div>
  </ng-container>
    
  <ng-content></ng-content>

    <div class="grid">
      <div class="col-6">
          <!-- <p-radioButton [(ngModel)]="rsvp.response" value="ACCEPT" /> -->
          <label>Joyfully Accept</label>
      </div>
      <div class="col-6">
          <!-- <p-radioButton [(ngModel)]="rsvp.response" value="DECLINE" /> -->
          <label>Regretfully Decline</label>
      </div>
    </div>
    <button class="p-button" (click)="onChildClick()">Send Response</button>
`
})
export class EventInvitationRSVP implements OnDynamicMount {
  @Input() invitation!: EventGuestInvitation;
  @Output() onClick: EventEmitter<any> = new EventEmitter();

  rsvp: Rsvp = {}

  onDynamicMount(data: OnDynamicData): void {
    // Contains the context object and the content children
    const context = data.context;
    const contentChildren = data.contentChildren;

    console.log(context);
    console.log(contentChildren);
  }

  onChildClick() {
    console.log("child click");
  }
}

@Component({
  selector: 'app-event-invitation-template-viewer',
  styles: `.viewer-container {max-height: 100vh; overflow: scroll}`,
  template: `<div class="viewer-container">
              <ngx-dynamic-hooks [content]="templateCode" [context]="{invitation: invitation, onClick: onParentClick}"></ngx-dynamic-hooks>
              </div>`
})
export class EventInvitationTemplateViewerComponent implements OnDynamicMount {
  @Input() invitation?: EventGuestInvitation;
  @Input() templateCode: string = '';
  parser = [EventInvitationRSVP, RadioButtonModule];

  onDynamicMount(data: OnDynamicData): void {
    // Contains the context object and the content children
    const context = data.context;
    const contentChildren = data.contentChildren;

    // console.log(context);
    // console.log(contentChildren);
  }

  onParentClick() {
    console.log('Hello');
  }
}
