import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { VendorDetailsComponent } from './components/vendor-details/vendor-details.component';
import { VendorListComponent } from './components/vendor-list/vendor-list.component';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: VendorListComponent
  },
  {
    path: 'add',
    pathMatch: 'full',
    component: VendorDetailsComponent
  },
  {
    path: ':vendorId',
    children: [
      {
        path: 'edit',
        pathMatch: 'full',
        component: VendorDetailsComponent
      }
    ]
  },
];

@NgModule({
  declarations: [
    VendorDetailsComponent,
    VendorListComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class VendorModule { }
