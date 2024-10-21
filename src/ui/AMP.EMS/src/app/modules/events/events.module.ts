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
import { EventListComponent } from './event-list/event-list.component';
import { AppSettingsComponent } from './settings/settings.component';
import { CheckboxModule } from 'primeng/checkbox';
import { CalendarModule } from 'primeng/calendar';
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { InputTextareaModule } from "primeng/inputtextarea";
import { InputNumberModule } from 'primeng/inputnumber';
import { EventsLayoutComponent } from '../../layout/events-layout/events-layout.component';
import { autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { TabViewModule } from 'primeng/tabview';
import { MenuModule } from 'primeng/menu';
import { EventDetailsComponent } from '../event/event-details/event-details.component';
import { DataViewModule } from 'primeng/dataview';
import { DefaultComponent } from '../default/default.component';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    EventListComponent,
    DefaultComponent,
    AppSettingsComponent,
  ],
  imports: [
    ButtonModule,
    CheckboxModule,
    CommonModule,
    CalendarModule,
    DataViewModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    MenuModule,
    RouterModule,
    TableModule,
    TooltipModule,
    RippleModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule,
    RouterModule.forChild([
      {
        path: 'events',
        component: EventsLayoutComponent,
        canActivate: [autoLoginPartialRoutesGuard],
        children: [
          {
            path: '',
            pathMatch: 'full',
            title: 'Events',
            data: { breadcrumb: 'Events' },
            component: EventListComponent
          },
          {
            path: 'add',
            title: 'Add Event',
            data: { breadcrumb: 'Add Event' },
            component: EventDetailsComponent,
          },
          {
            path: 'settings',
            title: 'Settings',
            data: { breadcrumb: 'Configuration' },
            component: AppSettingsComponent,
          }
        ]
      }
    ])
  ]
})

export class EventsModule { }
