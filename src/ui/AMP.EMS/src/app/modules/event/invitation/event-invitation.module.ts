import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { CodeEditorModule } from '@ngstack/code-editor';
import { DynamicHooksComponent } from 'ngx-dynamic-hooks';

import {
  EventGuestInvitationRSVPDateComponent,
  EventGuestInvitationRSVPFormComponent,
  EventGuestInvitationRSVPLabelComponent,
  EventInvitationDetailsComponent,
  EventInvitationGuestListComponent,
  EventInvitationListComponent
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
    pathMatch: 'full',
    data: { breadcrumb: null },
    component: EventInvitationDetailsComponent,
  },
  {
    path: ':eventInvitationId',
    title: 'Invitation',
    data: { breadcrumb: null },
    children: [
      {
        path: 'edit',
        pathMatch: 'full',
        component: EventInvitationDetailsComponent,
      }
    ]

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
    EventGuestInvitationRSVPDateComponent,
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
