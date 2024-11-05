import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventVendorContractListComponent, EventVendorDetailsComponent, EventVendorListComponent, EventVendorTransactionListComponent } from '@modules/event/vendor';
import { SharedModule } from '@modules/shared.module';

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
  }
]

@NgModule({
  declarations: [
    EventVendorListComponent,
    EventVendorDetailsComponent,
    EventVendorContractListComponent,
    EventVendorTransactionListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class EventVendorModule { }
