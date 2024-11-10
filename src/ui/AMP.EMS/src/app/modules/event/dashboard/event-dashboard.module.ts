import { NgModule } from '@angular/core';
import { EventDashboardComponent } from './components/event-dashboard/event-dashboard.component';
import { ChartModule } from 'primeng/chart';
import { SharedModule } from '@modules/shared.module';

@NgModule({
  declarations: [EventDashboardComponent],
  imports: [
    SharedModule,
    ChartModule,
  ]
})
export class EventDashboardModule { }
