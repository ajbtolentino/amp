import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventVendorTypeBudgetService } from '@modules/event';
import { EventVendorTypeBudget } from '@shared/models/event-vendor-type-budget.model';
import { Lookup } from '@shared/models/lookup.model';
import { map, Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-type-budget-details',
  templateUrl: './event-vendor-type-budget-details.component.html',
  styleUrl: './event-vendor-type-budget-details.component.scss'
})
export class EventVendorTypeBudgetDetailsComponent implements OnInit {
  eventVendorTypeBudget$: Observable<EventVendorTypeBudget> = new Observable<EventVendorTypeBudget>();
  vendorTypes$: Observable<Lookup[]> = new Observable<Lookup[]>();

  constructor(private eventVendorTypeBudgetService: EventVendorTypeBudgetService,
    private lookupService: LookupService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventVendorTypeBudget$ = this.loadEventVendorTypeBudget();
    this.vendorTypes$ = this.lookupService.getAll('vendortype');
  }

  loadEventVendorTypeBudget = () => {
    const eventVendorTypeBudgetId = this.route.snapshot.paramMap.get("eventVendorTypeBudgetId") || '';
    const eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    if (!eventVendorTypeBudgetId)
      return of<EventVendorTypeBudget>({ eventId: eventId, vendorType: {} });

    return this.eventVendorTypeBudgetService.get(eventVendorTypeBudgetId)
      .pipe(switchMap(eventVendorTypeBudget => this.loadVendorTypes(eventVendorTypeBudget)));
  }

  loadVendorTypes = (eventVendorTypeBudget: EventVendorTypeBudget): Observable<EventVendorTypeBudget> => {
    return this.lookupService.getAll('vendortype')
      .pipe(
        map(vendorTypes => ({
          ...eventVendorTypeBudget,
          vendorType: vendorTypes.find(_ => _.id === eventVendorTypeBudget.vendorTypeId)
        }))
      );
  }

  delete = (eventVendorTypeBudget: EventVendorTypeBudget) => {

  }

  save = (eventVendorTypeBudget: EventVendorTypeBudget) => {
    if (eventVendorTypeBudget.id) {
      this.eventVendorTypeBudget$ = this.eventVendorTypeBudgetService.update(eventVendorTypeBudget).pipe(switchMap(() => this.loadEventVendorTypeBudget()));
    }
    else {
      this.eventVendorTypeBudget$ = this.eventVendorTypeBudgetService.add(eventVendorTypeBudget).
        pipe(
          tap(eventVendorTypeBudget => {
            this.router.navigate(['events', eventVendorTypeBudget.eventId, 'budgets', eventVendorTypeBudget.id, 'edit']);
          })
        );
    }
  }
}
