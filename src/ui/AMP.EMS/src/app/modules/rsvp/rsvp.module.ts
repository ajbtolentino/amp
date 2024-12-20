import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvitationDetailsComponent } from './invitation-details/invitation-details.component';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RouterModule, RouterOutlet } from '@angular/router';
import { EmptyLayoutComponent } from '../../layout/empty-layout/empty-layout.component';
import { DynamicHooksComponent } from 'ngx-dynamic-hooks';
import { SharedModule } from '@modules/shared.module';

@NgModule({
  declarations: [EmptyLayoutComponent, InvitationDetailsComponent],
  imports: [
    ButtonModule,
    CommonModule,
    CardModule,
    DynamicHooksComponent,
    FormsModule,
    RadioButtonModule,
    RouterOutlet,
    RouterModule.forChild([
      {
        path: '',
        component: EmptyLayoutComponent,
        children: [
          {
            path: ':code',
            title: 'Invitation',
            component: InvitationDetailsComponent
          }
        ]
      },
    ]),
    SharedModule
  ]
})
export class RsvpModule { }
