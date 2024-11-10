import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, LookupService, VendorService } from '@core/services';
import { EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, Vendor } from '@shared/models';
import { ConfirmationService, SelectItem } from 'primeng/api';
import { DataView } from 'primeng/dataview';
import { Observable, map, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-contract-list',
  templateUrl: './event-vendor-contract-list.component.html',
  styleUrl: './event-vendor-contract-list.component.scss'
})
export class EventVendorContractListComponent implements OnInit {
  eventId!: string;
  eventVendorContracts: Observable<EventVendorContract[]> = new Observable<EventVendorContract[]>();

  sortOptions: SelectItem[] = [];
  sortOrder: number = 0;
  sortField: string = '';

  constructor(private eventService: EventService,
    private vendorService: VendorService,
    private lookupService: LookupService,
    private eventVendorContractService: EventVendorContractService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    this.eventVendorContracts = this.loadEventVendorContracts();

    this.sortOptions = [
      { label: 'Name', value: 'vendor.name' },
      { label: 'Description', value: 'vendor.description' },
      { label: 'Type', value: 'vendor.vendorType.name' }
    ];
  }

  loadEventVendorContracts = () => {
    return this.eventService.getVendorContracts(this.eventId).pipe(
      switchMap(eventVendorContracts => this.loadVendors(eventVendorContracts))
    );
  }

  loadEventVendorContractStates = (eventVendorContracts: EventVendorContract[]): Observable<EventVendorContract[]> => {
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

  loadVendors = (eventVendorContracts: EventVendorContract[]): Observable<EventVendorContract[]> => {
    if (!eventVendorContracts.length) return of<EventVendorContract[]>([]);

    return this.vendorService.getByIds(eventVendorContracts.map(_ => _.vendorId!))
      .pipe(
        switchMap(vendors => this.loadVendorType(vendors)),
        map(vendors => {
          return eventVendorContracts.map(eventVendorContract => ({
            ...eventVendorContract,
            vendor: vendors.find(_ => _.id === eventVendorContract.vendorId)
          }))
        })
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
    this.eventVendorContracts = this.eventVendorContractService.add(
      {
        vendorId: vendor.id!,
        eventId: this.eventId,
      }).pipe(
        switchMap(() => this.loadEventVendorContracts())
      );
  }

  viewContract = (eventVendorContract: EventVendorContract) => {
    this.router.navigate([`/events/${this.eventId}/vendors/contracts/${eventVendorContract.id}`]);
  }

  remove = (eventVendorContract: EventVendorContract) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${eventVendorContract.vendor?.name}? This is not reversible!`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.eventVendorContracts = this.eventVendorContractService.delete(eventVendorContract.id!)
          .pipe(
            switchMap(() => this.loadEventVendorContracts())
          );
      }
    });
  }

  onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
  }

  onFilterByType = (dv: DataView, event: Event) => {

  }
}
