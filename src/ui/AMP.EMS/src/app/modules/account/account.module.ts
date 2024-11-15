import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AccountDetailsComponent, AccountListComponent } from '@modules/account';
import { SharedModule } from '@modules/shared.module';

@NgModule({
  declarations: [
    AccountDetailsComponent, AccountListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [AccountListComponent, RouterModule]
})
export class AccountModule { }
