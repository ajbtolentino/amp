import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService } from '@core/services';
import { EventVendorTypeBudget } from '@shared/models/event-vendor-type-budget.model';
import { Observable, map, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-type-budget-list',
  templateUrl: './event-vendor-type-budget-list.component.html',
  styleUrl: './event-vendor-type-budget-list.component.scss'
})
export class EventVendorTypeBudgetListComponent implements OnInit {
  eventId!: string;
  eventVendorTypeBudgets$: Observable<EventVendorTypeBudget[]> = new Observable<EventVendorTypeBudget[]>()

  constructor(private eventService: EventService, private lookupService: LookupService, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';
    this.eventVendorTypeBudgets$ = this.loadEventVendorTypeBudgets();
  }

  loadEventVendorTypeBudgets = () => {
    return this.eventService.getVendorTypeBudgets(this.eventId)
      .pipe(
        switchMap(eventVendorTypeBudgets => this.loadVendorType(eventVendorTypeBudgets))
      );
  }

  loadVendorType = (eventVendorTypeBudgets: EventVendorTypeBudget[]): Observable<EventVendorTypeBudget[]> => {
    return this.lookupService.getByIds('vendortype', eventVendorTypeBudgets.map(_ => _.vendorTypeId!))
      .pipe(
        map(vendorTypes => eventVendorTypeBudgets.map(eventVendorTypeBudget => ({
          ...eventVendorTypeBudget,
          vendorType: vendorTypes.find(_ => _.id === eventVendorTypeBudget.vendorTypeId)
        })))
      );
  }
}
