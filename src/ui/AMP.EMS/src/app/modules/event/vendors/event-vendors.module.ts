import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@modules/shared.module';
import { EventVendorListComponent, EventVendorDetailsComponent } from '@modules/event/vendors';

@NgModule({
  declarations: [
    EventVendorListComponent,
    EventVendorDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class EventVendorsModule { }
