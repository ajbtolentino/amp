import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { EventVendorTypeBudgetDetailsComponent } from './components/event-vendor-type-budget-details/event-vendor-type-budget-details.component';
import { EventVendorTypeBudgetListComponent } from './components/event-vendor-type-budget-list/event-vendor-type-budget-list.component';

const routes: Routes = [
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
];

@NgModule({
  declarations: [EventVendorTypeBudgetDetailsComponent, EventVendorTypeBudgetListComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class BudgetModule { }
