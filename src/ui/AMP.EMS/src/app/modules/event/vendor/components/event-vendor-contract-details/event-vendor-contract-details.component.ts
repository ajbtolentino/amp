import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LookupService, VendorService } from '@core/services';
import { EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, Vendor } from '@shared/models';
import { Lookup } from '@shared/models/lookup-model';
import { concatMap, iif, map, Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-contract-details',
  templateUrl: './event-vendor-contract-details.component.html',
  styleUrl: './event-vendor-contract-details.component.scss'
})
export class EventVendorContractDetailsComponent implements OnInit {
  eventVendorContract$: Observable<EventVendorContract> = new Observable<EventVendorContract>();
  eventVendorContractStates$: Observable<Lookup[]> = new Observable<Lookup[]>();
  eventVendorContractPaymentStates$: Observable<Lookup[]> = new Observable<Lookup[]>();

  constructor(private eventVendorContractService: EventVendorContractService,
    private lookupService: LookupService,
    private vendorService: VendorService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventVendorContract$ = this.loadEventVendorContract();
    this.eventVendorContractStates$ = this.lookupService.getAll('eventVendorContractState');
    this.eventVendorContractPaymentStates$ = this.lookupService.getAll('eventVendorContractPaymentState');
  }

  loadEventVendorContract = (): Observable<EventVendorContract> => {
    const eventVendorContractId = this.route.snapshot.paramMap.get("eventVendorContractId") || '';
    const eventId = this.route.snapshot.parent?.parent?.parent?.paramMap.get("eventId");
    const vendorId = this.route.snapshot.paramMap.get("vendorId");

    if (eventVendorContractId)
      return this.eventVendorContractService.get(eventVendorContractId)
        .pipe(concatMap(eventVendorContract => this.loadEventVendorContractState(eventVendorContract)), concatMap(eventVendorContract => this.loadVendor(eventVendorContract)));

    return of<EventVendorContract>({ eventId: eventId!, vendorId: vendorId! }).pipe(concatMap(eventVendorContract => this.loadVendor(eventVendorContract)));
  }

  loadEventVendorContractState = (eventVendorContract: EventVendorContract): Observable<EventVendorContract> => {
    return iif(() => eventVendorContract.eventVendorContractStateId != null, this.lookupService.get('eventVendorContractState', eventVendorContract.eventVendorContractStateId!)
      .pipe(map(eventVendorContractState => ({ ...eventVendorContract, eventVendorContractState: eventVendorContractState }))), of<EventVendorContract>({ ...eventVendorContract }))
  }

  loadVendor = (eventVendorContract: EventVendorContract): Observable<EventVendorContract> => {
    return this.vendorService.get(eventVendorContract.vendorId).pipe(switchMap((vendor) => this.loadVendorType(vendor)))
      .pipe(map((vendor) => ({ ...eventVendorContract, vendor: vendor })));
  }

  loadVendorType = (vendor: Vendor) => {
    return this.lookupService.get('vendorType', vendor.vendorTypeId!).pipe(map((vendorType) => ({ ...vendor, vendorType: vendorType })));
  }

  save = (eventVendorContract: EventVendorContract) => {
    if (eventVendorContract.id) {
      this.eventVendorContract$ = this.eventVendorContractService.update({
        id: eventVendorContract.id,
        eventId: eventVendorContract.eventId,
        vendorId: eventVendorContract.vendorId,
        amount: eventVendorContract.amount,
        details: eventVendorContract.details,
        eventVendorContractStateId: eventVendorContract.eventVendorContractStateId
      }).pipe(switchMap(() => this.loadEventVendorContract()));
    }
    else {
      this.eventVendorContract$ = this.eventVendorContractService.add({
        eventId: eventVendorContract.eventId!,
        vendorId: eventVendorContract.vendorId!,
        amount: eventVendorContract.amount,
        details: eventVendorContract.details,
        eventVendorContractStateId: eventVendorContract.eventVendorContractStateId
      }).pipe(tap((e) => this.router.navigate([`/event/${eventVendorContract.eventId}/vendors/${eventVendorContract.vendorId}/contracts/${e.id}`])));
    }
  }
}
