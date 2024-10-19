import { Component, OnInit } from '@angular/core';
import { Event } from '../../../core/models/event';
import { EventService } from '../../../core/services/event.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EventTypeService } from '../../../core/services/event-type.service';
import { EventType } from '../../../core/models/event-type';


@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss',
})
export class EventDetailsComponent implements OnInit {
  loading: boolean = true;

  event: Event = {};

  eventTypeCollection: EventType[] = [];

  date: Date | undefined;

  constructor(private eventService: EventService, private eventTypeService: EventTypeService, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.route.parent?.params.subscribe((params) => {
      this.loadEvent(params["eventId"]);
    });
  }

  loadEvent = async (eventId: string | undefined | null) => {
    this.loading = true;

    if (eventId) {
      const response = await this.eventService.get(eventId);

      if (response.data) {
        this.event = response.data;
        this.event.startDate = new Date(response.data.startDate);
        this.event.endDate = new Date(response.data.endDate);

        console.log(this.event);
      }
    }

    await this.loadEventTypes();

    this.loading = false;
  }

  loadEventTypes = async () => {
    const response = await this.eventTypeService.getAll();

    if (response?.data) this.eventTypeCollection = response.data;
  }

  save = async () => {
    if (this.event?.title?.trim()) {
      if (this.event.id) {
        await this.eventService.update(this.event);
      }
      else {
        await this.eventService.add(this.event);
      }
    }

    this.router.navigate(["events"]);
  }
}
