import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LookupService, VendorService } from '@core/services';
import { EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract } from '@shared/models';
import { iif, map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-contract-details',
  templateUrl: './event-vendor-contract-details.component.html',
  styleUrl: './event-vendor-contract-details.component.scss'
})
export class EventVendorContractDetailsComponent implements OnInit {
  eventVendorContractId!: string;
  eventVendorContract$: Observable<EventVendorContract> = new Observable<EventVendorContract>();

  constructor(private eventVendorContractService: EventVendorContractService,
    private lookupService: LookupService,
    private vendorService: VendorService,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.eventVendorContractId = this.route.snapshot.paramMap.get("eventVendorContractId") || '';
    this.eventVendorContract$ = this.eventVendorContractService.get(this.eventVendorContractId)
      .pipe(
        switchMap(eventVendorContract => this.vendorService.get(eventVendorContract.vendorId).pipe(
          map(vendor => ({ ...eventVendorContract, vendor: vendor })))),
        switchMap(eventVendorContract => this.lookupService.get('vendorType', eventVendorContract.vendor.vendorTypeId!).pipe(
          map(vendorType => ({ ...eventVendorContract, vendor: { ...eventVendorContract.vendor, vendorType: vendorType } }))
        )),
        switchMap(eventVendorContract => iif(() => eventVendorContract.eventVendorContractStateId != null, this.lookupService.get('eventVendorContractState', eventVendorContract.eventVendorContractStateId!)
          .pipe(map(eventVendorContractState => ({ ...eventVendorContract, eventVendorContractState: eventVendorContractState }))), of<EventVendorContract>({ ...eventVendorContract }))),
        switchMap(eventVendorContract => iif(() => eventVendorContract.eventVendorContractPaymentStateId != null, this.lookupService.get('eventVendorContractPaymentState', eventVendorContract.eventVendorContractPaymentStateId!)
          .pipe(map(eventVendorContractPaymentState => ({ ...eventVendorContract, eventVendorContractPaymentState: eventVendorContractPaymentState }))), of<EventVendorContract>({ ...eventVendorContract })))
      );
  }
}
