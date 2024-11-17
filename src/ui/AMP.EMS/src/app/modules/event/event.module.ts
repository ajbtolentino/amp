import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  EventAccountDetailsComponent,
  EventAccountListComponent,
  EventDashboardComponent,
  EventDetailsComponent,
  EventGuestDetailsComponent,
  EventGuestInvitationRSVPDateComponent,
  EventGuestInvitationRSVPFormComponent,
  EventGuestInvitationRSVPLabelComponent,
  EventGuestListComponent,
  EventInvitationDetailsComponent,
  EventInvitationGuestListComponent,
  EventInvitationListComponent,
  EventListComponent,
  EventRolesComponent,
  EventTaskListComponent,
  EventVendorContractDetailsComponent,
  EventVendorContractListComponent,
  EventVendorListComponent,
  EventVendorTransactionListComponent,
  EventVendorTypeBudgetDetailsComponent,
  EventVendorTypeBudgetListComponent,
  SeatGroupComponent,
  TimelineListComponent,
  TransactionListComponent
} from '@modules/event';
import { SharedModule } from '@modules/shared.module';
import { VendorDetailsComponent } from '@modules/vendor/components/vendor-details/vendor-details.component';
import { CodeEditorModule } from '@ngstack/code-editor';
import { EventLayoutComponent } from 'app/layout/event-layout/event-layout.component';
import { EventsLayoutComponent } from 'app/layout/events-layout/events-layout.component';
import { DynamicHooksComponent } from 'ngx-dynamic-hooks';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: EventsLayoutComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        component: EventListComponent
      },
    ]
  },
  {
    path: 'add',
    title: 'Add Event',
    data: { breadcrumb: 'Add Event' },
    component: EventsLayoutComponent,
    children: [
      {
        path: '',
        component: EventDetailsComponent,
      },
    ]
  },
  {
    path: ':eventId',
    title: 'Event',
    component: EventLayoutComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard'
      },
      {
        path: 'dashboard',
        pathMatch: 'full',
        title: 'Dashboard',
        data: { breadcrumb: 'Dashboard' },
        component: EventDashboardComponent
      },
      {
        path: 'edit',
        title: 'Event Settings',
        data: { breadcrumb: 'Edit Event' },
        component: EventDetailsComponent,
      },
      {
        path: 'budgets',
        title: 'Budget',
        data: { breadcrumb: 'Budget' },
        children: [
          {
            path: '',
            pathMatch: 'full',
            title: 'Budgets',
            data: { breadcrumb: null },
            component: EventVendorTypeBudgetListComponent,
          },
          {
            path: 'add',
            pathMatch: 'full',
            title: 'Budgets',
            data: { breadcrumb: null },
            component: EventVendorTypeBudgetDetailsComponent,
          },
          {
            path: ':eventVendorTypeBudgetId/edit',
            pathMatch: 'full',
            title: 'Budgets',
            data: { breadcrumb: null },
            component: EventVendorTypeBudgetDetailsComponent,

          },
        ]
      },
      {
        path: 'vendors',
        title: 'Vendors',
        data: { breadcrumb: 'Vendors' },
        children: [
          {
            path: '',
            component: EventVendorListComponent
          },
          {
            path: 'transactions',
            component: EventVendorTransactionListComponent
          },
          {
            path: 'contracts',
            pathMatch: 'full',
            component: EventVendorContractListComponent
          },
          {
            path: ':vendorId',
            children: [
              {
                path: 'edit',
                component: VendorDetailsComponent
              },
              {
                path: 'contracts/draft',
                pathMatch: 'full',
                component: EventVendorContractDetailsComponent
              },
              {
                path: 'contracts/:vendorContractId',
                component: EventVendorContractDetailsComponent
              }
            ]
          }
        ]
      },
      {
        path: 'guests',
        title: 'Guests',
        data: { breadcrumb: 'Guests' },
        children: [
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
        ]
      },
      {
        path: 'invitations',
        data: { breadcrumb: 'Invitations' },
        children: [
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
        ]
      },
      {
        path: 'accounts',
        data: { breadcrumb: 'Accounts' },
        children: [
          {
            path: '',
            pathMatch: 'full',
            component: EventAccountListComponent
          },
          {
            path: 'add',
            pathMatch: 'full',
            component: EventAccountDetailsComponent
          },
          {
            path: ':accountId',
            children: [
              {
                path: 'edit',
                pathMatch: 'full',
                component: EventAccountDetailsComponent
              }
            ]
          }
        ]
      },
      {
        path: 'transactions',
        component: TransactionListComponent
      },
      {
        path: 'timeline',
        component: TimelineListComponent
      },
      {
        path: 'tasks',
        component: EventTaskListComponent
      },
      {
        path: 'seat-assignment',
        component: SeatGroupComponent
      },
    ]
  },
]

@NgModule({
  declarations: [
    EventVendorListComponent,
    EventVendorContractListComponent,
    EventVendorTransactionListComponent,
    EventVendorContractDetailsComponent,
    EventInvitationListComponent,
    EventInvitationDetailsComponent,
    EventInvitationGuestListComponent,
    EventGuestInvitationRSVPLabelComponent,
    EventGuestInvitationRSVPDateComponent,
    EventGuestInvitationRSVPFormComponent,
    EventGuestListComponent,
    EventGuestDetailsComponent,
    EventDashboardComponent,
    EventVendorTypeBudgetListComponent,
    EventAccountListComponent,
    EventVendorTypeBudgetDetailsComponent,
    EventListComponent,
    EventDetailsComponent,
    EventRolesComponent,
    EventAccountDetailsComponent,
    TransactionListComponent,
    SeatGroupComponent,
    EventTaskListComponent,
    TimelineListComponent,
  ],
  imports: [
    SharedModule,
    DynamicHooksComponent,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes)
  ],
  exports: [
    EventInvitationListComponent,
    EventInvitationDetailsComponent,
    EventInvitationGuestListComponent,
    EventGuestInvitationRSVPLabelComponent,
    EventGuestInvitationRSVPDateComponent,
    EventGuestInvitationRSVPFormComponent,
    EventGuestListComponent,
    EventGuestDetailsComponent,
    EventDashboardComponent,
    EventVendorTypeBudgetDetailsComponent,
    EventVendorTypeBudgetListComponent,
    EventAccountListComponent,
    EventListComponent,
    EventDetailsComponent,
    EventRolesComponent,
    TransactionListComponent,
    SeatGroupComponent,
    EventTaskListComponent,
    TimelineListComponent,
    RouterModule]
})

export class EventModule { }
