import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from '@core/services/event.service';
import { VendorTypeService } from '@core/services/vendor-type.service';
import { VendorService } from '@core/services/vendor.service';
import { EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, Vendor } from '@shared/models';
import { ConfirmationService, SelectItem } from 'primeng/api';
import { DataView } from 'primeng/dataview';
import { forkJoin, map, Observable, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-vendors',
  templateUrl: './event-vendor-list.component.html',
})
export class EventVendorListComponent implements OnInit {
  eventId!: string;
  vendors$: Observable<Vendor[]> = new Observable<Vendor[]>();

  sortOptions: SelectItem[] = [];
  sortOrder: number = 0;
  sortField: string = '';

  constructor(private eventService: EventService,
    private vendorService: VendorService,
    private vendorTypeService: VendorTypeService,
    private eventVendorContractService: EventVendorContractService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    this.vendors$ = this.refresh();

    this.sortOptions = [
      { label: 'Name', value: 'name' },
      { label: 'Description', value: 'description' },
      { label: 'Type', value: 'vendorType.name' }
    ];
  }

  refresh = () => {
    return forkJoin({
      vendors: this.vendorService.getAll(),
      vendorTypes: this.vendorTypeService.getAll(),
      eventVendorContracts: this.eventService.getVendorContracts(this.eventId),
      eventVendorContractStates: this.eventService.getVendorContractStates(this.eventId),
    }).pipe(
      map(({ vendors, vendorTypes, eventVendorContracts, eventVendorContractStates }) =>
        vendors.map(vendor => ({
          ...vendor,
          vendorType: vendorTypes.find(_ => _.id === vendor.vendorTypeId),
          eventVendorContracts: eventVendorContracts.filter(_ => _.vendorId === vendor.id)
            .map(eventVendorContract => ({
              ...eventVendorContract,
              vendor: vendor,
              eventVendorContractState: eventVendorContractStates.find(_ => _.id === eventVendorContract.eventVendorContractStateId)
            })),
        }))
      ));
  }

  onSortChange(event: any) {
    const value = event.value;

    if (value.indexOf('!') === 0) {
      this.sortOrder = -1;
      this.sortField = value.substring(1, value.length);
    } else {
      this.sortOrder = 1;
      this.sortField = value;
    }
  }

  add = (vendor: Vendor) => {
    this.vendors$ = this.eventVendorContractService.add(
      {
        vendorId: vendor.id!,
        eventId: this.eventId,
      }).pipe(switchMap((eventVendorContract) => {
        this.viewContract(eventVendorContract);
        return [];
      }
      ));
  }

  viewContract = (eventVendorContract: EventVendorContract) => {
    this.router.navigate([`/event/${this.eventId}/vendors/contracts/${eventVendorContract.id}`]);
  }

  onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
  }
}
