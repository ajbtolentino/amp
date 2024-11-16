import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService } from '@core/services';
import { EventService } from '@core/services/event.service';
import { VendorService } from '@core/services/vendor.service';
import { VendorContractService } from '@modules/event';
import { Vendor, VendorContract } from '@shared/models';
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
    private vendorContractService: VendorContractService,
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
    if (!vendors.length) return of<Vendor[]>(vendors);

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
    return this.vendorContractService.getByVendorIds(vendors.map(_ => _.id!))
      .pipe(
        switchMap(eventVendorContracts => this.loadVendorContractStates(eventVendorContracts)),
        map(eventVendorContracts => {
          return vendors.map(vendor => ({
            ...vendor,
            eventVendorContracts: eventVendorContracts.filter(_ => _.vendorId === vendor.id)
          }))
        })
      );
  }

  loadVendorContractStates = (vendorContracts: VendorContract[]): Observable<VendorContract[]> => {
    if (!vendorContracts?.filter(_ => _.vendorContractStateId).length) return of<VendorContract[]>(vendorContracts);

    return this.lookupService.getByIds('vendorContractState', vendorContracts.map(_ => _.vendorContractStateId!))
      .pipe(
        map(vendorContractStates => {
          return vendorContracts.map(vendorContract => ({
            ...vendorContract,
            eventVendorContractState: vendorContractStates.find(_ => _.id === vendorContract.vendorContractStateId)
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

  onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
  }
}
