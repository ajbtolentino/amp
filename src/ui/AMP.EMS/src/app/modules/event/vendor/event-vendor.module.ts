import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventVendorContractListComponent, EventVendorDetailsComponent, EventVendorListComponent, EventVendorTransactionListComponent } from '@modules/event/vendor';
import { SharedModule } from '@modules/shared.module';
import { EventVendorContractDetailsComponent } from './components/event-vendor-contract-details/event-vendor-contract-details.component';

const routes: Routes = [
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
    component: EventVendorContractListComponent
  },
  {
    path: 'contracts/:eventVendorContractId',
    pathMatch: 'full',
    component: EventVendorContractDetailsComponent
  }
]

@NgModule({
  declarations: [
    EventVendorListComponent,
    EventVendorDetailsComponent,
    EventVendorContractListComponent,
    EventVendorTransactionListComponent,
    EventVendorContractDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class EventVendorModule { }
