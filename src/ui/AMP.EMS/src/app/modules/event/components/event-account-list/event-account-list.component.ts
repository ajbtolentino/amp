import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { EventAccount } from '@shared/models';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-account-list',
  templateUrl: './event-account-list.component.html',
  styleUrl: './event-account-list.component.scss'
})
export class EventAccountListComponent implements OnInit {
  eventAccounts$: Observable<string[]> = new Observable<string[]>();

  constructor(private route: ActivatedRoute, private eventService: EventService) {

  }

  ngOnInit(): void {
    this.eventAccounts$ = this.route.parent?.parent?.paramMap
      .pipe(
        switchMap(params => this.loadEventAccounts(params.get("eventId")!)),
        map(eventAccounts => eventAccounts.map(_ => _.accountId!))
      ) || of<string[]>([]);
  }

  loadEventAccounts = (eventId: string): Observable<EventAccount[]> => {
    return this.eventService.getEventAccounts(eventId);
  }
}
