import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService, TransactionService } from '@core/services';
import { Transaction } from '@shared/models';
import { ConfirmationService } from 'primeng/api';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.scss'
})
export class TransactionListComponent implements OnInit {
  transactions$: Observable<Transaction[]> = new Observable<Transaction[]>();

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private confirmationService: ConfirmationService,
    private transactionService: TransactionService,
    private lookupService: LookupService) { }

  ngOnInit(): void {
    this.transactions$ = this.route.parent?.paramMap
      .pipe(
        switchMap(params => this.loadTransactions(params.get("eventId")!))
      ) || of<Transaction[]>([]);
  }

  loadTransactions = (eventId: string): Observable<Transaction[]> => {
    return this.eventService.getTransactions(eventId)
      .pipe(
        switchMap(transactions => this.loadTransactionTypes(transactions))
      );
  }

  loadTransactionTypes = (transactions: Transaction[]): Observable<Transaction[]> => {
    return this.lookupService.getByIds('transactiontype', transactions.filter(_ => _.transactionTypeId).map(_ => _.transactionTypeId!))
      .pipe(
        map(transactionTypes => transactions.map(
          transaction => ({
            ...transaction,
            transactionType: transactionTypes.find(_ => _.id === transaction.transactionTypeId)
          })
        ))
      )
  }

  delete = (id: string) => {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete this transaction?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        this.transactions$ = this.transactionService.delete(id)
          .pipe(
            switchMap(() => this.route.parent?.paramMap!),
            switchMap(params => this.loadTransactions(params.get("eventId")!))
          )
      }
    });
  }
}
