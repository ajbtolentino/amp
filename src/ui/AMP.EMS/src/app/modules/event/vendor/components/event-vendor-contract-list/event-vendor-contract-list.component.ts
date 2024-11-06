import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, VendorService } from '@core/services';
import { VendorTypeService } from '@core/services/vendor-type.service';
import { EventVendorContract, Vendor } from '@shared/models';
import { ConfirmationService, SelectItem } from 'primeng/api';
import { DataView } from 'primeng/dataview';
import { Observable, forkJoin, map, switchMap } from 'rxjs';
import { EventVendorContractService } from '../../services/event-vendor-contract.service';

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
    private vendorTypeService: VendorTypeService,
    private eventVendorContractService: EventVendorContractService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.paramMap.get("eventId") || '';

    this.eventVendorContracts = this.refresh();

    this.sortOptions = [
      { label: 'Name', value: 'vendor.name' },
      { label: 'Description', value: 'vendor.description' },
      { label: 'Type', value: 'vendor.vendorType.name' }
    ];
  }

  refresh = () => {
    return forkJoin({
      vendors: this.vendorService.getAll(),
      vendorTypes: this.vendorTypeService.getAll(),
      eventVendorContracts: this.eventService.getVendorContracts(this.eventId),
      eventVendorContractStates: this.eventService.getVendorContractStates(this.eventId),
      eventVendorContractPaymentStates: this.eventService.getVendorContractPaymentStates(this.eventId)
    }).pipe(
      map(({ vendors, vendorTypes, eventVendorContracts, eventVendorContractStates, eventVendorContractPaymentStates }) =>
        eventVendorContracts.map(eventVendorContract => ({
          ...eventVendorContract,
          vendor: vendors.map(vendor => ({ ...vendor, vendorType: vendorTypes.find(_ => _.id === vendor.vendorTypeId) })).find(_ => _.id === eventVendorContract.vendorId),
          eventVendorContractState: eventVendorContractStates.find(_ => _.id === eventVendorContract.eventVendorContractStateId),
          eventVendorContractPaymentState: eventVendorContractPaymentStates.find(_ => _.id === eventVendorContract.eventVendorContractPaymentStateId)
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
    this.eventVendorContracts = this.eventVendorContractService.add(
      {
        vendorId: vendor.id!,
        eventId: this.eventId,
      }).pipe(switchMap(() => this.refresh()));
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
        this.eventVendorContracts = this.eventVendorContractService.delete(eventVendorContract.id!).pipe(switchMap(() => this.refresh()));
      }
    });
  }

  onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
  }

  onFilterByType = (dv: DataView, event: Event) => {

  }
}
