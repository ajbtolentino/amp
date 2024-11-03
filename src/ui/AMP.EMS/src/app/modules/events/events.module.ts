import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventListComponent } from './event-list/event-list.component';
import { AppSettingsComponent } from './settings/settings.component';
import { EventDetailsComponent } from '../event/settings/components/event-details/event-details.component';
import { DefaultComponent } from '../default/default.component';
import { SharedModule } from '@modules/shared.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    EventListComponent,
    DefaultComponent,
    AppSettingsComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild([
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
    ])
  ]
})

export class EventsModule { }
