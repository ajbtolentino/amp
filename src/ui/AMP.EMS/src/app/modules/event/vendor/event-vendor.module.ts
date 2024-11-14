import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventVendorContractListComponent, EventVendorListComponent, EventVendorTransactionListComponent } from '@modules/event/vendor';
import { SharedModule } from '@modules/shared.module';
import { VendorDetailsComponent } from '@modules/vendor/components/vendor-details/vendor-details.component';
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
  },
]

@NgModule({
  declarations: [
    EventVendorListComponent,
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
