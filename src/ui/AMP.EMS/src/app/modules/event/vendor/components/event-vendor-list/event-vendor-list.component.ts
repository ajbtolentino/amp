import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { VendorService } from '@core/services/vendor.service';
import { EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, Vendor } from '@shared/models';
import { SelectItem } from 'primeng/api';
import { DataView } from 'primeng/dataview';
import { map, Observable, of, switchMap } from 'rxjs';

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
    private lookupService: LookupService,
    private eventVendorContractService: EventVendorContractService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    this.vendors$ = this.loadVendors();

    this.sortOptions = [
      { label: 'Name', value: 'name' },
      { label: 'Description', value: 'description' },
      { label: 'Type', value: 'vendorType.name' }
    ];
  }

  loadVendors = (): Observable<Vendor[]> => {
    return this.vendorService.getAll()
      .pipe(
        switchMap(vendors => this.loadVendorType(vendors)),
        switchMap(vendors => this.loadEventVendorContracts(vendors))
      );
  }

  loadVendorType = (vendors: Vendor[]): Observable<Vendor[]> => {
    if (!vendors.length) return of<Vendor[]>();

    return this.lookupService.getByIds('vendortype', vendors.map(_ => _.vendorTypeId!))
      .pipe(
        map(vendorTypes => {
          return vendors.map(vendor => ({
            ...vendor,
            vendorType: vendorTypes.find(_ => _.id === vendor.vendorTypeId)
          }))
        })
      )
  }

  loadEventVendorContracts = (vendors: Vendor[]): Observable<Vendor[]> => {
    return this.eventVendorContractService.getByVendorIds(vendors.map(_ => _.id!))
      .pipe(
        switchMap(eventVendorContracts => this.loadEventVendorContractStates(eventVendorContracts)),
        map(eventVendorContracts => {
          return vendors.map(vendor => ({
            ...vendor,
            eventVendorContracts: eventVendorContracts.filter(_ => _.vendorId === vendor.id)
          }))
        })
      );
  }

  loadEventVendorContractStates = (eventVendorContracts: EventVendorContract[]): Observable<EventVendorContract[]> => {
    if (!eventVendorContracts?.filter(_ => _.eventVendorContractStateId).length) return of<EventVendorContract[]>([]);

    return this.lookupService.getByIds('eventVendorContractState', eventVendorContracts.map(_ => _.eventVendorContractStateId!))
      .pipe(
        map(eventVendorContractStates => {
          return eventVendorContracts.map(eventVendorContract => ({
            ...eventVendorContract,
            eventVendorContractState: eventVendorContractStates.find(_ => _.id === eventVendorContract.eventVendorContractStateId)
          }))
        })
      )
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
