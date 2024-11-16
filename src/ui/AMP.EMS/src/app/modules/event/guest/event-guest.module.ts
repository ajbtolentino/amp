import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';

import { EventGuestDetailsComponent, EventGuestListComponent } from '@modules/event/guest';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    title: 'Event Guests',
    data: { breadcrumb: null },
    component: EventGuestListComponent,
  },
  {
    path: 'add',
    pathMatch: 'full',
    title: 'Add Guest',
    data: { breadcrumb: 'Add' },
    component: EventGuestDetailsComponent,
  },
  {
    path: ':eventGuestId/edit',
    data: { breadcrumb: 'Guest Details' },
    component: EventGuestDetailsComponent,
  }
];

@NgModule({
  declarations: [EventGuestListComponent, EventGuestDetailsComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class EventGuestModule { }
