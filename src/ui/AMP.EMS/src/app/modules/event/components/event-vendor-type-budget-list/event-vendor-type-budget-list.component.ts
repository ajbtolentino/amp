import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService } from '@core/services';
import { EventVendorTypeBudgetService } from '@modules/event';
import { EventVendorTypeBudget } from '@shared/models/event-vendor-type-budget.model';
import { ConfirmationService } from 'primeng/api';
import { Observable, map, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-type-budget-list',
  templateUrl: './event-vendor-type-budget-list.component.html',
  styleUrl: './event-vendor-type-budget-list.component.scss'
})
export class EventVendorTypeBudgetListComponent implements OnInit {
  eventId!: string;
  eventVendorTypeBudgets$: Observable<EventVendorTypeBudget[]> = new Observable<EventVendorTypeBudget[]>()

  constructor(private eventService: EventService,
    private eventVendorBudgetTypeService: EventVendorTypeBudgetService,
    private confirmationService: ConfirmationService,
    private lookupService: LookupService,
    private route: ActivatedRoute) {

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

  remove = (eventVendorTypeBudget: EventVendorTypeBudget) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete? This is not reversible!`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.eventVendorTypeBudgets$ = this.eventVendorBudgetTypeService.delete(eventVendorTypeBudget.id!)
          .pipe(
            switchMap(() => this.loadEventVendorTypeBudgets())
          )
      }
    });
  }
}
