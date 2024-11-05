import { NgModule } from '@angular/core';
import { EventDetailsComponent, EventRolesComponent } from '@modules/event/settings';
import { SharedModule } from '@modules/shared.module';


@NgModule({
  declarations: [EventDetailsComponent, EventRolesComponent],
  imports: [
    SharedModule
  ]
})
export class EventSettingsModule { }
