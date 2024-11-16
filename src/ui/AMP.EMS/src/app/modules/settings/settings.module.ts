import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { EventTypeListComponent } from './components/event-type-list/event-type-list.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'event-types'
  },
  {
    path: 'event-types',
    component: EventTypeListComponent
  }
]

@NgModule({
  declarations: [
    EventTypeListComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    EventTypeListComponent,
    RouterModule
  ]
})
export class SettingsModule { }
