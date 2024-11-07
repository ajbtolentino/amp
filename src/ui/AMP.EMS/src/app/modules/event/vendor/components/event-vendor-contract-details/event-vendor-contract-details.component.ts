import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, LookupService, VendorService } from '@core/services';
import { EventVendorContractPaymentService, EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, EventVendorContractPayment, Vendor } from '@shared/models';
import { Lookup } from '@shared/models/lookup-model';
import { ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { concatMap, iif, map, Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-event-vendor-contract-details',
  templateUrl: './event-vendor-contract-details.component.html',
  styleUrl: './event-vendor-contract-details.component.scss'
})
export class EventVendorContractDetailsComponent implements OnInit {
  eventId!: string;
  vendorId!: string;

  eventVendorContract$: Observable<EventVendorContract> = new Observable<EventVendorContract>();
  eventVendorContractStates$: Observable<Lookup[]> = new Observable<Lookup[]>();

  eventVendorContractPayments$: Observable<EventVendorContractPayment[]> = new Observable<EventVendorContractPayment[]>();
  eventVendorContractPaymentTypes$: Observable<Lookup[]> = new Observable<Lookup[]>();
  eventVendorContractPaymentStates$: Observable<Lookup[]> = new Observable<Lookup[]>();

  @ViewChild('dt') dt!: Table;

  constructor(private eventVendorContractService: EventVendorContractService,
    private eventVendorContractPaymentService: EventVendorContractPaymentService,
    private eventService: EventService,
    private lookupService: LookupService,
    private vendorService: VendorService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.parent?.parent?.parent?.paramMap.get("eventId")!;
    this.vendorId = this.route.snapshot.paramMap.get("vendorId")!;

    this.eventVendorContract$ = this.loadEventVendorContract();
    this.eventVendorContractStates$ = this.eventService.getVendorContractStates(this.eventId);
    this.eventVendorContractPaymentTypes$ = this.eventService.getVendorContractPaymentTypes(this.eventId);
    this.eventVendorContractPaymentStates$ = this.eventService.getVendorContractPaymentStates(this.eventId);
  }

  loadEventVendorContract = (): Observable<EventVendorContract> => {
    const eventVendorContractId = this.route.snapshot.paramMap.get("eventVendorContractId") || '';

    if (eventVendorContractId) {
      this.eventVendorContractPayments$ = this.loadPayments(eventVendorContractId);

      return this.eventVendorContractService.get(eventVendorContractId)
        .pipe(
          concatMap(eventVendorContract => this.loadEventVendorContractState(eventVendorContract)),
          concatMap(eventVendorContract => this.loadVendor(eventVendorContract)));
    }

    this.eventVendorContractPayments$ = of<EventVendorContractPayment[]>([{ eventVendorContractPaymentStateId: '', eventVendorContractPaymentTypeId: '', eventVendorContractId: eventVendorContractId }])

    return of<EventVendorContract>({ eventId: this.eventId, vendorId: this.vendorId! }).pipe(concatMap(eventVendorContract => this.loadVendor(eventVendorContract)));
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

  loadPayments = (eventVendorContractId: string) => {
    return this.eventVendorContractService.getPayments(eventVendorContractId)
      .pipe(map(eventVendorContractPayments => [{ eventVendorContractId: eventVendorContractId }, ...eventVendorContractPayments.map(_ => {
        if (_.dueDate) _.dueDate = new Date(_.dueDate);
        return _;
      })]),
        tap(eventVendorContractPayments => this.dt.initRowEdit(eventVendorContractPayments.at(0))));
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

  delete = (eventVendorContractPayment: EventVendorContractPayment) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete this payment?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (eventVendorContractPayment.id) {
          this.eventVendorContractPayments$ = this.eventVendorContractPaymentService.delete(eventVendorContractPayment.id)
            .pipe(switchMap(() => this.loadPayments(eventVendorContractPayment.eventVendorContractId!)));
        }
      }
    });
  }

  savePayment = (eventVendorContractPayment: EventVendorContractPayment) => {
    if (eventVendorContractPayment.id) {
      this.eventVendorContractPayments$ = this.eventVendorContractPaymentService.update(eventVendorContractPayment)
        .pipe(switchMap(() => this.loadPayments(eventVendorContractPayment.eventVendorContractId!)));
    }
    else {
      this.eventVendorContractPayments$ = this.eventVendorContractPaymentService.add(eventVendorContractPayment)
        .pipe(switchMap(() => this.loadPayments(eventVendorContractPayment.eventVendorContractId!)));
    }
  }
}
