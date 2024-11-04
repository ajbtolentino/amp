import { NgModule } from '@angular/core';
import { SharedModule } from '@modules/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { CodeEditorModule } from '@ngstack/code-editor';
import { DynamicHooksComponent } from 'ngx-dynamic-hooks';

import {
  EventInvitationListComponent,
  EventInvitationDetailsComponent,
  EventInvitationGuestListComponent,
  EventGuestInvitationRSVPFormComponent,
  EventGuestInvitationRSVPLabelComponent
} from '@modules/event/invitation';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    title: 'Invitations',
    data: { breadcrumb: null },
    component: EventInvitationListComponent,
  },
  {
    path: 'add',
    title: 'Add Invitation',
    data: { breadcrumb: null },
    component: EventInvitationDetailsComponent,
  },
  {
    path: ':eventInvitationId/edit',
    pathMatch: 'full',
    title: 'Invitation',
    data: { breadcrumb: null },
    component: EventInvitationDetailsComponent,
  },
  {
    path: ':eventInvitationId/guests',
    pathMatch: 'full',
    title: 'Invitation',
    data: { breadcrumb: null },
    component: EventInvitationGuestListComponent,
  },
];

@NgModule({
  declarations: [
    EventInvitationListComponent,
    EventInvitationDetailsComponent,
    EventInvitationGuestListComponent,
    EventGuestInvitationRSVPLabelComponent,
    EventGuestInvitationRSVPFormComponent
  ],
  imports: [
    SharedModule,
    DynamicHooksComponent,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes),
  ],
  exports: [RouterModule]
})
export class EventInvitationModule { }
