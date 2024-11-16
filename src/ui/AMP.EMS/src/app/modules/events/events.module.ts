import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { EventListComponent } from '../event/components/event-list/event-list.component';
import { AppSettingsComponent } from './settings/settings.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    title: 'Events',
    data: { breadcrumb: 'Events' },
    component: EventListComponent
  },
  {
    path: 'settings',
    title: 'Settings',
    data: { breadcrumb: 'Configuration' },
    component: AppSettingsComponent,
  }
];

@NgModule({
  declarations: [
    AppSettingsComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class EventsModule { }
