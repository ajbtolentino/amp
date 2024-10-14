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

@NgModule({
  declarations: [
    EventDetailsComponent,
    EventListComponent,
    EventTypesComponent,
    GuestListComponent
  ],
  imports: [
    ButtonModule,
    CheckboxModule,
    CommonModule,
    CalendarModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
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
            data: {
              breadcrumb: 'Events'
            },
            component: EventListComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'event-types',
            title: 'Manage Events Types',
            data: {
              breadcrumb: 'Event Types'
            },
            component: EventTypesComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'events/:id',
            data: {
              breadcrumb: 'Event'
            },
            component: EventDetailsComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'guests',
            title: 'Manage Guests',
            component: GuestListComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
        ]
      }
    ])
  ]
})

export class AdminModule { }
