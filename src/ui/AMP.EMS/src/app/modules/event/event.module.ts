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
import { EventRolesComponent } from './event-roles/event-roles.component';
import { EventDashboardComponent } from './event-dashboard/event-dashboard.component';
import { EventLayoutComponent } from '../../layout/event-layout/event-layout.component';
import { EventInvitationTemplateEditorComponent } from './event-invitations/event-invitation-template-editor.component';
import { EditorModule } from 'primeng/editor';
import { EventInvitationTemplateViewerComponent } from './event-invitations/event-invitation-template-viewer.component';
import { EventInvitationTemplateViewerDirective } from './event-invitations/event-invitation-template-viewer.directive';
import { TabViewModule } from 'primeng/tabview';

@NgModule({
  declarations: [
    EventDetailsComponent,
    EventGuestsComponent,
    EventInvitationsComponent,
    EventInvitationTemplateEditorComponent,
    EventRolesComponent,
    EventInvitationTemplateViewerComponent,
    EventInvitationTemplateViewerDirective,
  ],
  imports: [
    ButtonModule,
    CheckboxModule,
    CommonModule,
    CalendarModule,
    DropdownModule,
    EditorModule,
    FormsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
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
        path: ':id',
        title: 'EMS',
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
            title: 'Invitations',
            data: { breadcrumb: null },
            component: EventInvitationsComponent,
          },
          {
            path: 'guests',
            title: 'Guests',
            data: { breadcrumb: 'Guests' },
            component: EventGuestsComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          },
          {
            path: 'roles',
            title: 'Roles',
            data: { breadcrumb: 'Roles' },
            component: EventRolesComponent,
            canActivate: [autoLoginPartialRoutesGuard],
          }
        ]
      }
    ])
  ]
})

export class EventModule { }
