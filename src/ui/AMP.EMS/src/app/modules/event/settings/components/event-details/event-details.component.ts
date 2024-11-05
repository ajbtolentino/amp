import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventTypeService } from '@core/services/event-type.service';
import { EventService } from '@core/services/event.service';
import { Event, EventType } from '@shared/models';
import { map, Observable, of, tap } from 'rxjs';


@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html'
})
export class EventDetailsComponent implements OnInit {
  eventId!: string;
  event$: Observable<Event> = new Observable<Event>();
  eventTypes$: Observable<EventType[]> = new Observable<EventType[]>();

  constructor(private eventService: EventService,
    private eventTypeService: EventTypeService,
    private router: Router,
    private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.eventId = this.route.parent?.snapshot.paramMap.get("eventId") || '';
    this.loadEvent();
  }

  loadEvent = () => {
    this.event$ = of<Event>({});

    if (this.eventId) {
      this.event$ = this.eventService.get(this.eventId).pipe(map(event => {
        if (event.startDate) event.startDate = new Date(event.startDate);
        if (event.endDate) event.endDate = new Date(event.endDate);
        return event;
      }));
    }

    this.loadEventTypes();
  }

  loadEventTypes = async () => {
    this.eventTypes$ = this.eventTypeService.getAll();
  }

  save = (event: Event) => {
    if (event?.title?.trim()) {
      if (event.id) {
        this.event$ = this.eventService.update(event).pipe(tap((event) => this.loadEvent()));
      }
      else {
        this.eventService.add(event).pipe(tap((event) => {
          this.redirect(event);
        }));
      }
    }
  }

  redirect = (item: any) => {
    this.router.navigate([`/event/${item.id}`]);
  }
}
