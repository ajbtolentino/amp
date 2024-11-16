import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService } from '@core/services';
import { Transaction } from '@shared/models';
import { Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.scss'
})
export class TransactionListComponent implements OnInit {
  transactions$: Observable<Transaction[]> = new Observable<Transaction[]>();

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private lookupService: LookupService) { }

  ngOnInit(): void {
    this.transactions$ = this.route.parent?.paramMap
      .pipe(
        switchMap(params => this.loadTransactions(params.get("eventId")!))
      ) || of<Transaction[]>([]);
  }

  loadTransactions = (eventId: string): Observable<Transaction[]> => {
    return this.eventService.getTransactions(eventId);
  }
}
