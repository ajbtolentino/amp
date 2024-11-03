import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';

import { EventGuestListComponent, EventGuestDetailsComponent } from '@modules/event/guest';

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
    title: 'Add Guest',
    data: { breadcrumb: null },
    component: EventGuestDetailsComponent,
  },
  {
    path: ':eventGuestId/edit',
    data: { breadcrumb: null },
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
