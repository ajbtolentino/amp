import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, LookupService, VendorService } from '@core/services';
import { VendorContractService } from '@modules/event/vendor';
import { Vendor, VendorContract } from '@shared/models';
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
  vendorContracts: Observable<VendorContract[]> = new Observable<VendorContract[]>();

  sortOptions: SelectItem[] = [];
  sortOrder: number = 0;
  sortField: string = '';

  constructor(private eventService: EventService,
    private vendorService: VendorService,
    private lookupService: LookupService,
    private vendorContractService: VendorContractService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    this.vendorContracts = this.loadVendorContracts();

    this.sortOptions = [
      { label: 'Name', value: 'vendor.name' },
      { label: 'Description', value: 'vendor.description' },
      { label: 'Type', value: 'vendor.vendorType.name' }
    ];
  }

  loadVendorContracts = () => {
    return this.eventService.getVendorContracts(this.eventId).pipe(
      switchMap(eventVendorContracts => this.loadVendors(eventVendorContracts)),
      switchMap(eventVendorContracts => this.loadEventVendorContractStates(eventVendorContracts))
    );
  }

  loadEventVendorContractStates = (vendorContracts: VendorContract[]): Observable<VendorContract[]> => {
    return this.lookupService.getByIds('vendorContractState', vendorContracts.map(_ => _.vendorContractStateId!))
      .pipe(
        map(vendorContractStates => {
          (vendorContractStates)
          return vendorContracts.map(vendorContract => ({
            ...vendorContract,
            vendorContractState: vendorContractStates.find(_ => _.id === vendorContract.vendorContractStateId)
          }))
        })
      )
  }

  loadVendors = (vendorContracts: VendorContract[]): Observable<VendorContract[]> => {
    if (!vendorContracts.length) return of<VendorContract[]>([]);

    return this.vendorService.getByIds(vendorContracts.map(_ => _.vendorId!))
      .pipe(
        switchMap(vendors => this.loadVendorType(vendors)),
        map(vendors => {
          return vendorContracts.map(vendorContract => ({
            ...vendorContract,
            vendor: vendors.find(_ => _.id === vendorContract.vendorId)
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
    this.vendorContracts = this.vendorContractService.add(
      {
        vendorId: vendor.id!,
        eventId: this.eventId,
      }).pipe(
        switchMap(() => this.loadVendorContracts())
      );
  }

  viewContract = (vendorContract: VendorContract) => {
    this.router.navigate([`/events/${this.eventId}/vendors/contracts/${vendorContract.id}`]);
  }

  remove = (vendorContract: VendorContract) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${vendorContract.vendor?.name}? This is not reversible!`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.vendorContracts = this.vendorContractService.delete(vendorContract.id!)
          .pipe(
            switchMap(() => this.loadVendorContracts())
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
