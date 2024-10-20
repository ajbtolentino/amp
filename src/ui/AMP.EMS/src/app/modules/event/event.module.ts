import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { TooltipModule } from 'primeng/tooltip';
import { EventDetailsComponent } from './event-details/event-details.component';
import { CheckboxModule } from 'primeng/checkbox';
import { EventGuestsComponent } from './event-guests/event-guests.component';
import { autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { CalendarModule } from 'primeng/calendar';
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { InputTextareaModule } from "primeng/inputtextarea";
import { EventInvitationsComponent } from './event-invitations/event-invitations.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { EventDashboardComponent } from './event-dashboard/event-dashboard.component';
import { EventLayoutComponent } from '../../layout/event-layout/event-layout.component';
import { EditorModule } from 'primeng/editor';
import { EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent } from './event-invitation/event-guest-invitation-rsvp.component';
import { TabViewModule } from 'primeng/tabview';
import { EventGuestInvitationComponent } from './event-guest-invitation/event-guest-invitation.component';
import { EventInvitationComponent } from './event-invitation/event-invitation.component';
import { EventGuestInvitationsComponent } from './event-invitation/event-guest-invitations.component';
import { DynamicHooksComponent } from 'ngx-dynamic-hooks';
import { CodeEditorModule } from '@ngstack/code-editor';
import { EventGuestDetailsComponent } from './event-guests/event-guest-details.component';
import { ChartModule } from 'primeng/chart';
import { MenuModule } from 'primeng/menu';
import { MultiSelectModule } from 'primeng/multiselect';
import { EventRolesComponent } from './event-details/event-roles.component';

@NgModule({
  declarations: [
    EventDashboardComponent,
    EventDetailsComponent,
    EventGuestsComponent,
    EventInvitationsComponent,
    EventGuestInvitationRSVPFormComponent,
    EventGuestInvitationRSVPLabelComponent,
    EventGuestInvitationComponent,
    EventInvitationComponent,
    EventGuestInvitationsComponent,
    EventGuestDetailsComponent,
    EventRolesComponent
  ],
  imports: [
    ButtonModule,
    ChartModule,
    CheckboxModule,
    CommonModule,
    CalendarModule,
    CodeEditorModule.forChild(),
    DropdownModule,
    DynamicHooksComponent,
    EditorModule,
    FormsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    MenuModule,
    MultiSelectModule,
    RouterModule,
    TableModule,
    TooltipModule,
    RippleModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule,
    RouterModule.forChild([
      {
        path: '',
        pathMatch: 'full',
        redirectTo: '/events'
      },
      {
        path: ':eventId',
        title: 'EMS',
        canActivate: [autoLoginPartialRoutesGuard],
        component: EventLayoutComponent,
        children: [
          {
            path: 'dashboard',
            title: 'Dashboard',
            data: { breadcrumb: 'Dashboard' },
            component: EventDashboardComponent
          },
          {
            path: 'edit',
            title: 'Edit Event',
            data: { breadcrumb: 'Edit Event' },
            component: EventDetailsComponent,
          },
          {
            path: 'invitations',
            data: { breadcrumb: 'Invitations' },
            children: [
              {
                path: '',
                title: 'Invitations',
                data: { breadcrumb: null },
                component: EventInvitationsComponent,
              },
              {
                path: 'add',
                pathMatch: 'full',
                title: 'Add Invitation',
                data: { breadcrumb: null },
                component: EventInvitationComponent,
              }
            ]
          },
          {
            path: 'invitation',
            children: [
              {
                path: ':eventInvitationId',
                title: 'Invitation',
                data: { breadcrumb: null },
                component: EventInvitationComponent,
              }
            ]
          },
          {
            path: 'guests',
            title: 'Guests',
            data: { breadcrumb: 'Guests' },
            children: [
              {
                path: '',
                title: 'Event Guests',
                data: { breadcrumb: null },
                component: EventGuestsComponent,
              },
              {
                path: 'add',
                title: 'Add Guest',
                data: { breadcrumb: null },
                component: EventGuestDetailsComponent,
              }
            ]
          },
          {
            path: 'guest',
            children: [
              {
                path: ':eventGuestId',
                title: 'Edit Guest',
                data: { breadcrumb: null },
                component: EventGuestDetailsComponent,
              }
            ]
          }
        ]
      }
    ]),
  ]
})

export class EventModule { }
