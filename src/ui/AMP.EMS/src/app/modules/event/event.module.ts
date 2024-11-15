import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailsComponent, AccountListComponent } from '@modules/account';
import { EventAccountListComponent, EventDetailsComponent, EventListComponent, EventRolesComponent } from '@modules/event';
import { SharedModule } from '@modules/shared.module';
import { CodeEditorModule } from '@ngstack/code-editor';
import { EventLayoutComponent } from 'app/layout/event-layout/event-layout.component';
import { EventsLayoutComponent } from 'app/layout/events-layout/events-layout.component';
import { EventDashboardComponent } from './dashboard';
import { EventDashboardModule } from './dashboard/event-dashboard.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: EventsLayoutComponent,
    children: [
      {
        path: '',
        component: EventListComponent
      }
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
        loadChildren: () => import('@modules/event/budget/budget.module').then(m => m.BudgetModule)
      },
      {
        path: 'vendors',
        title: 'Vendors',
        data: { breadcrumb: 'Vendors' },
        loadChildren: () => import('@modules/event/vendor/event-vendor.module').then(m => m.EventVendorModule)
      },
      {
        path: 'guests',
        title: 'Guests',
        data: { breadcrumb: 'Guests' },
        loadChildren: () => import('@modules/event/guest/event-guest.module').then(m => m.EventGuestModule),
      },
      {
        path: 'invitations',
        data: { breadcrumb: 'Invitations' },
        loadChildren: () => import('@modules/event/invitation/event-invitation.module').then(m => m.EventInvitationModule)
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
            component: AccountDetailsComponent
          },
          {
            path: ':accountId',
            children: [
              {
                path: 'edit',
                pathMatch: 'full',
                component: AccountDetailsComponent
              }
            ]
          }
        ]
      }
    ]
  },
]

@NgModule({
  declarations: [
    EventAccountListComponent,
    EventListComponent,
    EventDetailsComponent,
    EventRolesComponent,
    AccountDetailsComponent,
    AccountListComponent,
  ],
  imports: [
    SharedModule,
    EventDashboardModule,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes)
  ],
  exports: [EventAccountListComponent,
    EventListComponent,
    EventDetailsComponent,
    EventRolesComponent,
    AccountDetailsComponent,
    AccountListComponent,
    RouterModule]
})

export class EventModule { }
