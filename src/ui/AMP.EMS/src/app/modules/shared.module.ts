import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WithStatusPipe } from '../core/pipes/with-status';

@NgModule({
  declarations: [WithStatusPipe],
  imports: [
    CommonModule
  ],
  exports: [
    WithStatusPipe
  ]
})
export class SharedModule { }
