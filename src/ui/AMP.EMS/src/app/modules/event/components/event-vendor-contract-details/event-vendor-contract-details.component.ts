import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService, LookupService, TransactionService, VendorService } from '@core/services';
import { VendorContractPaymentService, VendorContractService } from '@modules/event';
import { Transaction, TransactionType, Vendor, VendorContract, VendorContractPayment } from '@shared/models';
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

  vendorContract$: Observable<VendorContract> = new Observable<VendorContract>();
  vendorContractStates$: Observable<Lookup[]> = new Observable<Lookup[]>();

  vendorContractPayments$: Observable<VendorContractPayment[]> = new Observable<VendorContractPayment[]>();
  vendorContractPaymentTypes$: Observable<Lookup[]> = new Observable<Lookup[]>();
  vendorContractPaymentStates$: Observable<Lookup[]> = new Observable<Lookup[]>();

  transactionTypes$: Observable<Lookup[]> = new Observable<Lookup[]>();
  vendorContractPaymentTransaction$: Observable<VendorContractPayment> = new Observable<VendorContractPayment>();
  showTransactionDialog: boolean = false;

  @ViewChild('dt') dt!: Table;

  constructor(private vendorContractService: VendorContractService,
    private vendorContractPaymentService: VendorContractPaymentService,
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

    this.vendorContract$ = this.loadVendorContract();
    this.vendorContractStates$ = this.eventService.getVendorContractStates(this.eventId);
    this.vendorContractPaymentTypes$ = this.eventService.getVendorContractPaymentTypes(this.eventId);
    this.vendorContractPaymentStates$ = this.eventService.getVendorContractPaymentStates(this.eventId);
    this.transactionTypes$ = this.lookupService.getAll('transactiontype').pipe();
  }

  loadVendorContract = (): Observable<VendorContract> => {
    const vendorContractId = this.route.snapshot.paramMap.get("vendorContractId") || '';

    if (vendorContractId) {
      this.vendorContractPayments$ = this.loadPayments(vendorContractId);

      return this.vendorContractService.get(vendorContractId)
        .pipe(
          switchMap(vendorContract => this.loadVendorContractState(vendorContract)),
          switchMap(vendorContract => this.loadVendor(vendorContract)));
    }

    this.vendorContractPayments$ = of<VendorContractPayment[]>([{ vendorContractPaymentStateId: '', vendorContractPaymentTypeId: '', vendorContractId: vendorContractId }])

    return of<VendorContract>({ eventId: this.eventId, vendorId: this.vendorId! }).pipe(concatMap(eventVendorContract => this.loadVendor(eventVendorContract)));
  }

  loadVendorContractState = (vendorContract: VendorContract): Observable<VendorContract> => {
    return iif(() => vendorContract.vendorContractStateId != null, this.lookupService.get('vendorContractState', vendorContract.vendorContractStateId!)
      .pipe(map(vendorContractState => ({ ...vendorContract, vendorContractState: vendorContractState }))), of<VendorContract>({ ...vendorContract }))
  }

  loadVendor = (vendorContract: VendorContract): Observable<VendorContract> => {
    return this.vendorService.get(vendorContract.vendorId).pipe(switchMap((vendor) => this.loadVendorType(vendor)))
      .pipe(map((vendor) => ({ ...vendorContract, vendor: vendor })));
  }

  loadVendorType = (vendor: Vendor) => {
    return this.lookupService.get('vendorType', vendor.vendorTypeId!).pipe(map((vendorType) => ({ ...vendor, vendorType: vendorType })));
  }

  loadPayments = (eventVendorContractId: string) => {
    return this.vendorContractService.getPayments(eventVendorContractId)
      .pipe(
        switchMap(eventVendorContractPayments => this.loadTransactions(eventVendorContractPayments, eventVendorContractId)),
        map(eventVendorContractPayments => [{ vendorContractId: eventVendorContractId }, ...eventVendorContractPayments.map(_ => {
          if (_.dueDate) _.dueDate = new Date(_.dueDate);
          return _;
        })]),
        tap(eventVendorContractPayments => this.dt.initRowEdit(eventVendorContractPayments.at(0))));
  }

  loadTransactions = (vendorContractPayments: VendorContractPayment[], eventVendorContractId: string): Observable<VendorContractPayment[]> => {
    return this.vendorContractService.getTransactions(eventVendorContractId)
      .pipe(
        switchMap(transactions => this.loadTransactionTypes(transactions)),
        map(transactions => vendorContractPayments.map(vendorContractPayment => ({
          ...vendorContractPayment,
          transaction: transactions.map(_ => ({
            ..._,
            paymentType: !_.amount ? undefined : (_.amount >= 0 ? 'Credit' : 'Debit')
          })).find(_ => _.id === vendorContractPayment.transactionId)
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

  openTransaction = (vendorContractPayment: VendorContractPayment) => {
    this.vendorContractPaymentTransaction$ = of<VendorContractPayment>({
      ...vendorContractPayment
    }).pipe(
      switchMap(_ => this.loadTransaction(_)),
      tap(() => {
        this.showTransactionDialog = true;
      }));
  }

  loadTransaction = (vendorContractPayment: VendorContractPayment): Observable<VendorContractPayment> => {
    if (!vendorContractPayment.transactionId)
      return of<VendorContractPayment>({
        ...vendorContractPayment,
        transaction: {
          transactionDate: new Date(),
          amount: vendorContractPayment.dueAmount,
          paymentType: 'Debit'
        }
      });

    return this.vendorContractPaymentService.getTransaction(vendorContractPayment.id!).pipe(map(transaction => ({
      ...vendorContractPayment,
      transaction: {
        ...transaction,
        transactionDate: new Date(transaction.transactionDate!),
        paymentType: !transaction.amount ? undefined : (transaction.amount >= 0 ? 'Credit' : 'Debit')
      }
    })));
  }

  saveTransaction = (vendorContractPayment: VendorContractPayment) => {
    console.log(vendorContractPayment)
    if (vendorContractPayment.dueAmount && vendorContractPayment.vendorContractPaymentStateId && vendorContractPayment.vendorContractPaymentTypeId) {
      if (vendorContractPayment.transaction?.id) {
        this.vendorContractPaymentTransaction$ = this.transactionService.update(vendorContractPayment.transaction!)
          .pipe(
            tap(() => {
              this.vendorContractPayments$ = this.loadPayments(vendorContractPayment.vendorContractId!);
              this.closeTransactionDialog()
            }));
      }
      else {
        this.vendorContractPaymentTransaction$ = this.vendorContractPaymentService.addTransaction(vendorContractPayment.id!, vendorContractPayment.transaction!)
          .pipe(
            tap(() => {
              this.vendorContractPayments$ = this.loadPayments(vendorContractPayment.vendorContractId!);
              this.closeTransactionDialog()
            }));
      }
    }
  }

  closeTransactionDialog = () => {
    this.showTransactionDialog = false;
  }

  save = (vendorContract: VendorContract) => {
    if (vendorContract.id) {
      this.vendorContract$ = this.vendorContractService.update({
        id: vendorContract.id,
        eventId: vendorContract.eventId,
        vendorId: vendorContract.vendorId,
        amount: vendorContract.amount,
        details: vendorContract.details,
        vendorContractStateId: vendorContract.vendorContractStateId
      }).pipe(switchMap(() => this.loadVendorContract()));
    }
    else {
      this.vendorContract$ = this.vendorContractService.add({
        eventId: vendorContract.eventId!,
        vendorId: vendorContract.vendorId!,
        amount: vendorContract.amount,
        details: vendorContract.details,
        vendorContractStateId: vendorContract.vendorContractStateId
      }).pipe(tap((e) => this.router.navigate(['events', vendorContract.eventId, 'vendors', vendorContract.vendorId, 'contracts', e.id])));
    }
  }

  delete = (vendorContractPayment: VendorContractPayment) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete this payment?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        if (vendorContractPayment.id) {
          this.vendorContractPayments$ = this.vendorContractPaymentService.delete(vendorContractPayment.id)
            .pipe(switchMap(() => this.loadPayments(vendorContractPayment.vendorContractId!)));
        }
      }
    });
  }

  savePayment = (vendorContractPayment: VendorContractPayment) => {
    if (vendorContractPayment.dueAmount && vendorContractPayment.vendorContractPaymentStateId && vendorContractPayment.vendorContractPaymentTypeId) {
      if (vendorContractPayment.id) {
        this.vendorContractPayments$ = this.vendorContractPaymentService.update(vendorContractPayment)
          .pipe(switchMap(() => this.loadPayments(vendorContractPayment.vendorContractId!)));
      }
      else {
        this.vendorContractPayments$ = this.vendorContractPaymentService.add(vendorContractPayment)
          .pipe(switchMap(() => this.loadPayments(vendorContractPayment.vendorContractId!)));
      }
    }
  }
}
