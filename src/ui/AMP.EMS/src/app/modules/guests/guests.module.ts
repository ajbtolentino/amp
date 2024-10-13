import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvitationDetailsComponent } from './invitation-details/invitation-details.component';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RouterModule, RouterOutlet } from '@angular/router';
import { EmptyLayoutComponent } from '../../layout/empty-layout/empty-layout.component';

@NgModule({
  declarations: [EmptyLayoutComponent, InvitationDetailsComponent],
  imports: [
    ButtonModule,
    CommonModule,
    CardModule,
    FormsModule,
    RadioButtonModule,
    RouterOutlet,
    RouterModule.forChild([
      {
        path: '',
        component: EmptyLayoutComponent,
        children: [
          {
            path: 'invitation',
            title: 'RSVP',
            children: [
              {
                path: ':code',
                title: 'Invitation',
                component: InvitationDetailsComponent
              }
            ]
          }
        ]
      }
    ])
  ]
})
export class GuestModule { }
