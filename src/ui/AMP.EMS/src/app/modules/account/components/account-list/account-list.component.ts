import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LookupService } from '@core/services';
import { AccountService } from '@modules/account/services/account.service';
import { Account, EventAccount } from '@shared/models';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrl: './account-list.component.scss'
})
export class AccountListComponent implements OnInit {
  accounts$: Observable<Account[]> = new Observable<Account[]>();
  eventId!: string;
  @Input() accountIds: string[] = [];

  constructor(private route: ActivatedRoute,
    private accountService: AccountService,
    private lookupService: LookupService) {

  }

  ngOnInit(): void {
    this.accounts$ = this.loadAccounts();
  }

  loadAccounts = (): Observable<EventAccount[]> => {
    const service = this.accountIds.length ? this.accountService.getByIds(this.accountIds) : this.accountService.getAll();

    return service
      .pipe(
        switchMap(accounts => this.loadAccountTypes(accounts))
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
