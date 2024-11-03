import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventBudgetComponent } from './budget/components/event-budget-list/event-budget-list.component';
import { EventDashboardComponent } from './dashboard/components/event-dashboard/event-dashboard.component';
import { EventDetailsComponent } from './settings/components/event-details/event-details.component';
import { EventTransactionsComponent } from './event-transactions/event-transactions.component';
import { EventVendorListComponent } from './vendors/components/event-vendor-list/event-vendor-list.component';
import { EventVendorDetailsComponent } from './vendors/components/event-vendor-details/event-vendor-details.component';
import { EventInvitationModule } from './invitation/event-invitation.module';
import { EventGuestModule } from '@modules/event/guest/event-guest.module';
import { EventSettingsModule } from '@modules/event/settings/event-settings.module';
import { EventDashboardModule } from './dashboard/event-dashboard.module';
import { CodeEditorModule } from '@ngstack/code-editor';

@NgModule({
  declarations: [
    EventTransactionsComponent,
    EventBudgetComponent,
    EventVendorListComponent,
    EventVendorDetailsComponent
  ],
  imports: [
    EventDashboardModule,
    EventGuestModule,
    EventInvitationModule,
    EventSettingsModule,
    CodeEditorModule.forChild(),
    RouterModule.forChild([
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
        path: 'vendors',
        title: 'Vendors',
        data: { breadcrumb: 'Vendors' },
        component: EventVendorListComponent
      },
      {
        path: 'transactions',
        title: 'Transactions',
        data: { breadcrumb: 'Transactions' },
        component: EventTransactionsComponent
      },
      {
        path: 'budget',
        title: 'Budget',
        data: { breadcrumb: 'Budget' },
        component: EventBudgetComponent
      },
      {
        path: 'invitations',
        data: { breadcrumb: 'Invitations' },
        loadChildren: () => import('@modules/event/invitation/event-invitation.module').then(m => m.EventInvitationModule)
      },
      {
        path: 'guests',
        title: 'Guests',
        data: { breadcrumb: 'Guests' },
        loadChildren: () => import('@modules/event/guest/event-guest.module').then(m => m.EventGuestModule)
      },
    ])
  ],
  exports: []
})

export class EventModule { }
