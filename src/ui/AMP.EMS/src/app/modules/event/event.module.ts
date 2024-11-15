import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailsComponent } from '@modules/account';
import { AccountModule } from '@modules/account/account.module';
import { EventSettingsModule } from '@modules/event/settings/event-settings.module';
import { SharedModule } from '@modules/shared.module';
import { CodeEditorModule } from '@ngstack/code-editor';
import { EventAccountListComponent } from './components/event-account-list/event-account-list.component';
import { EventDashboardComponent } from './dashboard/components/event-dashboard/event-dashboard.component';
import { EventDashboardModule } from './dashboard/event-dashboard.module';
import { EventDetailsComponent } from './settings/components/event-details/event-details.component';

const routes: Routes = [
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
        component: EventAccountListComponent
      },
      {
        path: ':accountId/edit',
        component: AccountDetailsComponent
      }
    ]
  }
]

@NgModule({
  declarations: [
    EventAccountListComponent
  ],
  imports: [
    SharedModule,
    EventDashboardModule,
    EventSettingsModule,
    AccountModule,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes)
  ],
  exports: [EventAccountListComponent, RouterModule]
})

export class EventModule { }
