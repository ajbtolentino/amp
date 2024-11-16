import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailsComponent, AccountListComponent } from '@modules/account';
import { SharedModule } from '@modules/shared.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: AccountListComponent
  }
]

@NgModule({
  declarations: [
    AccountDetailsComponent, AccountListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports: [AccountListComponent, AccountDetailsComponent, RouterModule]
})

export class AccountModule { }
