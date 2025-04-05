import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  EventAccountDetailsComponent,
  EventAccountListComponent,
  EventDashboardComponent,
  EventDetailsComponent,
  EventGuestDetailsComponent,
  EventGuestInvitationRSVPChangeableLabelComponent,
  EventGuestInvitationRSVPDateComponent,
  EventGuestInvitationRSVPFormComponent,
  EventGuestInvitationRSVPLabelComponent,
  EventGuestInvitationYTPlayerComponent,
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
  SeatAssignmentComponent,
  TimelineListComponent,
  TransactionListComponent,
  ZoneListComponent
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
            title: 'Add Budget',
            data: { breadcrumb: 'Add' },
            component: EventVendorTypeBudgetDetailsComponent,
          },
          {
            path: ':eventVendorTypeBudgetId/edit',
            pathMatch: 'full',
            title: 'Edit Budget',
            data: { breadcrumb: 'Edit' },
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
            title: 'Search Vendors',
            path: '',
            data: { breadcrumb: null },
            component: EventVendorListComponent
          },
          {
            title: 'Transactions',
            path: 'transactions',
            data: { breadcrumb: 'Transactions' },
            component: EventVendorTransactionListComponent
          },
          {
            title: 'Contracts',
            path: 'contracts',
            data: { breadcrumb: 'Contracts' },
            children: [
              {
                path: '',
                pathMatch: 'full',
                data: { breadcrumb: null },
                component: EventVendorContractListComponent
              },
              {
                title: 'Edit Contract',
                path: ':vendorContractId',
                data: { breadcrumb: 'Edit' },
                component: EventVendorContractDetailsComponent
              }
            ]
          },
          {
            path: ':vendorId',
            data: { breadcrumb: null },
            children: [
              {
                title: 'Edit Vendor',
                path: 'edit',
                data: { breadcrumb: 'Edit' },
                component: VendorDetailsComponent
              },
              {
                title: 'Draft Contract',
                path: 'contracts/draft',
                pathMatch: 'full',
                data: { breadcrumb: 'Draft' },
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
            title: 'Guests',
            data: { breadcrumb: null },
            component: EventGuestListComponent,
          },
          {
            path: 'add',
            pathMatch: 'full',
            title: 'Add Guest',
            data: { breadcrumb: 'Add Guest' },
            component: EventGuestDetailsComponent,
          },
          {
            path: ':eventGuestId/edit',
            data: { breadcrumb: 'Edit Guest' },
            component: EventGuestDetailsComponent,
          }
        ]
      },
      {
        title: 'Invitations',
        path: 'invitations',
        data: { breadcrumb: 'Invitations' },
        children: [
          {
            title: 'Invitations',
            path: '',
            pathMatch: 'full',
            data: { breadcrumb: null },
            component: EventInvitationListComponent,
          },
          {
            path: 'add',
            title: 'Add Invitation',
            pathMatch: 'full',
            data: { breadcrumb: 'Add Invitation' },
            component: EventInvitationDetailsComponent,
          },
          {
            path: ':eventInvitationId',
            title: 'Invitation',
            data: { breadcrumb: null },
            children: [
              {
                title: 'Edit Invitation',
                path: 'edit',
                data: { breadcrumb: 'Edit' },
                pathMatch: 'full',
                component: EventInvitationDetailsComponent,
              }
            ]

          },
          {
            path: ':eventInvitationId/guests',
            pathMatch: 'full',
            title: 'Manage Recipients',
            data: { breadcrumb: 'Recipients' },
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
            data: { breadcrumb: null },
            component: EventAccountListComponent
          },
          {
            path: 'add',
            pathMatch: 'full',
            data: { breadcrumb: 'Add Account' },
            component: EventAccountDetailsComponent
          },
          {
            path: ':accountId',
            data: { breadcrumb: null },
            children: [
              {
                path: 'edit',
                pathMatch: 'full',
                data: { breadcrumb: 'Edit Account' },
                component: EventAccountDetailsComponent
              }
            ]
          }
        ]
      },
      {
        path: 'transactions',
        data: { breadcrumb: 'Transactions' },
        component: TransactionListComponent
      },
      {
        path: 'timeline',
        data: { breadcrumb: 'Timeline' },
        component: TimelineListComponent
      },
      {
        path: 'tasks',
        data: { breadcrumb: 'Tasks' },
        component: EventTaskListComponent
      },
      {
        path: 'zones',
        data: { breadcrumb: 'Zones' },
        component: ZoneListComponent
      },
      {
        path: 'seat-assignment',
        data: { breadcrumb: 'Seat Assignment' },
        component: SeatAssignmentComponent
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
    EventGuestInvitationRSVPChangeableLabelComponent,
    EventGuestInvitationYTPlayerComponent,
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
    EventTaskListComponent,
    TimelineListComponent,
    SeatAssignmentComponent,
    ZoneListComponent,
  ],
  imports: [
    SharedModule,
    DynamicHooksComponent,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule]
})

export class EventModule { }
