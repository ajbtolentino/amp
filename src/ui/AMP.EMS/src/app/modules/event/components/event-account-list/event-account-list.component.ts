import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService } from '@core/services';
import { AccountService } from '@modules/event';
import { Account, EventAccount } from '@shared/models';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-account-list',
  templateUrl: './event-account-list.component.html',
  styleUrl: './event-account-list.component.scss'
})
export class EventAccountListComponent implements OnInit {
  eventAccounts$: Observable<EventAccount[]> = new Observable<EventAccount[]>();

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private accountService: AccountService,
    private lookupService: LookupService) {

  }

  ngOnInit(): void {
    this.eventAccounts$ = this.route.parent?.parent?.paramMap
      .pipe(
        switchMap(params => this.loadEventAccounts(params.get("eventId")!)),
      ) || of<EventAccount[]>([]);
  }

  loadEventAccounts = (eventId: string): Observable<EventAccount[]> => {
    return this.eventService.getEventAccounts(eventId)
      .pipe(
        switchMap(eventAccounts => this.loadAccounts(eventAccounts))
      );
  }

  loadAccounts = (eventAccounts: EventAccount[]): Observable<EventAccount[]> => {
    return this.accountService.getByIds(eventAccounts.filter(_ => _.accountId).map(_ => _.accountId!))
      .pipe(
        switchMap(accounts => this.loadAccountTypes(accounts)),
        map(accounts => eventAccounts.map(eventAccount => ({
          ...eventAccount,
          account: accounts.find(_ => _.id === eventAccount.accountId)
        })))
      )
  }

  loadAccountTypes = (accounts: Account[]): Observable<Account[]> => {
    if (!accounts.filter(_ => _.accountTypeId).length) of<Account[]>([]);

    return this.lookupService.getByIds('accounttype', accounts.filter(_ => _.accountTypeId).map(_ => _.accountTypeId!))
      .pipe(
        map(accountTypes => accounts.map(account => ({
          ...account,
          accountType: accountTypes.find(_ => _.id === account.accountTypeId)
        }))
        )
      );
  }
}
