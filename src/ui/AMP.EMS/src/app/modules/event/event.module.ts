import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventSettingsModule } from '@modules/event/settings/event-settings.module';
import { CodeEditorModule } from '@ngstack/code-editor';
import { EventBudgetComponent } from './budget/components/event-budget-list/event-budget-list.component';
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
    path: 'budget',
    title: 'Budget',
    data: { breadcrumb: 'Budget' },
    component: EventBudgetComponent
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
  }
]

@NgModule({
  declarations: [
    EventBudgetComponent,
  ],
  imports: [
    EventDashboardModule,
    EventSettingsModule,
    CodeEditorModule.forChild(),
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class EventModule { }
