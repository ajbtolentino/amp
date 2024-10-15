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
import { EventListComponent } from './event-list/event-list.component';
import { EventTypesComponent } from './event-types/event-types.component';
import { CheckboxModule } from 'primeng/checkbox';
import { GuestListComponent } from './guest-list/guest-list.component';
import { autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { AppLayoutComponent } from '../../layout/app.layout.component';
import { CalendarModule } from 'primeng/calendar';
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { InputTextareaModule } from "primeng/inputtextarea";
import { EventInvitationsComponent } from './event-invitations/event-invitations.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { AppBreadcrumbsComponent } from '../../layout/app.breadcrumbs.component';

@NgModule({
  declarations: [
    EventDetailsComponent,
    EventListComponent,
    EventTypesComponent,
    GuestListComponent,
    EventInvitationsComponent
  ],
  imports: [
    ButtonModule,
    CheckboxModule,
    CommonModule,
    CalendarModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    RouterModule,
    TableModule,
    TooltipModule,
    RippleModule,
    SkeletonModule,
    ToolbarModule,
    RouterModule.forChild([
      {
        path: '',
        title: 'EMS',
        component: AppLayoutComponent,
        children: [
          {
            path: 'events',
            title: 'Manage Events',
            data: { breadcrumb: 'Events' },
            component: EventListComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'event',
            data: { breadcrumb: 'Events', },
            canActivate: [autoLoginPartialRoutesGuard],
            children: [
              {
                path: '',
                pathMatch: 'full',
                redirectTo: '/events'
              },
              {
                path: 'add',
                title: 'Add Event',
                data: { breadcrumb: 'Add Event' },
                component: EventDetailsComponent,
              },
              {
                path: 'edit/:id',
                title: 'Edit Event',
                data: { breadcrumb: 'Edit Event' },
                component: EventDetailsComponent,
              },
              {
                path: 'invitations/:id',
                title: 'Event Invitations',
                data: { breadcrumb: 'Event Invitations' },
                component: EventInvitationsComponent,
              }
            ]
          },
          {
            path: 'event-types',
            title: 'Manage Events Types',
            data: { breadcrumb: 'Event Types' },
            component: EventTypesComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'guests',
            title: 'Manage Guests',
            data: { breadcrumb: 'Manage Guests' },
            component: GuestListComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
        ]
      }
    ])
  ]
})

export class AdminModule { }
