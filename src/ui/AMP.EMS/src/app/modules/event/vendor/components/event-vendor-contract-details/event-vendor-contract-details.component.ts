import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, LookupService, TransactionService, VendorService } from '@core/services';
import { EventVendorContractPaymentService, EventVendorContractService } from '@modules/event/vendor';
import { EventVendorContract, EventVendorContractPayment, Transaction, TransactionType, Vendor } from '@shared/models';
import { Lookup } from '@shared/models/lookup.model';
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

  transactionTypes$: Observable<Lookup[]> = new Observable<Lookup[]>();
  eventVendorContractPaymentTransaction$: Observable<EventVendorContractPayment> = new Observable<EventVendorContractPayment>();
  showTransactionDialog: boolean = false;

  @ViewChild('dt') dt!: Table;

  constructor(private eventVendorContractService: EventVendorContractService,
    private eventVendorContractPaymentService: EventVendorContractPaymentService,
    private eventService: EventService,
    private lookupService: LookupService,
    private vendorService: VendorService,
    private confirmationService: ConfirmationService,
    private transactionService: TransactionService,
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
    this.transactionTypes$ = this.lookupService.getAll('transactiontype').pipe();
  }

  loadEventVendorContract = (): Observable<EventVendorContract> => {
    const eventVendorContractId = this.route.snapshot.paramMap.get("eventVendorContractId") || '';

    if (eventVendorContractId) {
      this.eventVendorContractPayments$ = this.loadPayments(eventVendorContractId);

      return this.eventVendorContractService.get(eventVendorContractId)
        .pipe(
          switchMap(eventVendorContract => this.loadEventVendorContractState(eventVendorContract)),
          switchMap(eventVendorContract => this.loadVendor(eventVendorContract)));
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
      .pipe(
        switchMap(eventVendorContractPayments => this.loadTransactions(eventVendorContractPayments)),
        map(eventVendorContractPayments => [{ eventVendorContractId: eventVendorContractId }, ...eventVendorContractPayments.map(_ => {
          if (_.dueDate) _.dueDate = new Date(_.dueDate);
          return _;
        })]),
        tap(eventVendorContractPayments => this.dt.initRowEdit(eventVendorContractPayments.at(0))));
  }

  loadTransactions = (eventVendorContractPayments: EventVendorContractPayment[]): Observable<EventVendorContractPayment[]> => {
    return this.transactionService.getByIds(eventVendorContractPayments.filter(_ => _.transactionId).map(_ => _.transactionId!))
      .pipe(
        switchMap(transactions => this.loadTransactionTypes(transactions)),
        map(transactions => eventVendorContractPayments.map(eventVendorContractPayment => ({
          ...eventVendorContractPayment,
          transaction: transactions.find(_ => _.id === eventVendorContractPayment.transactionId)
        })))
      )
  }

  loadTransactionTypes = (transactions: Transaction[]): Observable<Transaction[]> => {
    if (!transactions.filter(_ => _.transactionTypeId).length) return of<TransactionType[]>([]);

    return this.lookupService.getByIds('transactiontype', transactions.filter(_ => _.transactionTypeId).map(_ => _.transactionTypeId!))
      .pipe(
        map(transactionTypes => transactions.map(transaction => ({
          ...transaction,
          transactionType: transactionTypes.find(_ => _.id === transaction.transactionTypeId)
        })))
      );
  }

  openTransaction = (eventVendorContractPayment: EventVendorContractPayment) => {
    this.eventVendorContractPaymentTransaction$ = of<EventVendorContractPayment>({
      ...eventVendorContractPayment
    }).pipe(
      switchMap(_ => this.loadTransaction(_)),
      tap(() => {
        this.showTransactionDialog = true;
      }));
  }

  loadTransaction = (eventVendorContractPayment: EventVendorContractPayment): Observable<EventVendorContractPayment> => {
    if (!eventVendorContractPayment.transactionId)
      return of<EventVendorContractPayment>({
        ...eventVendorContractPayment,
        transaction: {
          transactionDate: new Date(),
          amount: eventVendorContractPayment.dueAmount
        }
      });

    return this.transactionService.get(eventVendorContractPayment.transactionId!).pipe(map(transaction => ({
      ...eventVendorContractPayment,
      transaction: {
        ...transaction,
        transactionDate: new Date(transaction.transactionDate!)
      }
    })));
  }

  saveTransaction = (eventVendorContractPayment: EventVendorContractPayment) => {
    if (eventVendorContractPayment.transaction?.id) {
      this.eventVendorContractPaymentTransaction$ = this.transactionService.update(eventVendorContractPayment.transaction!)
        .pipe(
          tap(() => {
            this.eventVendorContractPayments$ = this.loadPayments(eventVendorContractPayment.eventVendorContractId!);
            this.closeTransactionDialog()
          }));
    }
    else {
      this.eventVendorContractPaymentTransaction$ = this.eventVendorContractPaymentService.addTransaction(eventVendorContractPayment.id!, eventVendorContractPayment.transaction!)
        .pipe(
          tap(() => {
            this.eventVendorContractPayments$ = this.loadPayments(eventVendorContractPayment.eventVendorContractId!);
            this.closeTransactionDialog()
          }));
    }
  }

  closeTransactionDialog = () => {
    this.showTransactionDialog = false;
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
