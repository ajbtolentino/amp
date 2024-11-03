import { NgModule } from '@angular/core';
import { SharedModule } from '@modules/shared.module';
import { EventDetailsComponent, EventRolesComponent } from '@modules/event/settings';


@NgModule({
  declarations: [EventDetailsComponent, EventRolesComponent],
  imports: [
    SharedModule
  ]
})
export class EventSettingsModule { }
