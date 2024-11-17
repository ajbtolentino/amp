import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { TimelineService } from '@modules/event/services/timeline.service';
import { Timeline } from '@shared/models';
import { Table } from 'primeng/table';
import { map, Observable, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-timeline-list',
  templateUrl: './timeline-list.component.html',
  styleUrl: './timeline-list.component.scss'
})
export class TimelineListComponent implements OnInit {
  timelines$: Observable<Timeline[]> = new Observable<Timeline[]>();

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private timelineService: TimelineService) {

  }

  ngOnInit(): void {
    this.timelines$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadTimelines(params.get("eventId")!))
    ) || of<Timeline[]>([]);
  }

  loadTimelines = (eventId: string): Observable<Timeline[]> => {
    return this.eventService.getTimelines(eventId)
      .pipe(
        map(timelines => timelines.map(timeline => ({
          ...timeline,
          startDate: timeline.startDate ? new Date(timeline.startDate) : undefined,
          endDate: timeline.endDate ? new Date(timeline.endDate) : undefined
        })))
      );
  }

  addRow = (timelines: Timeline[]) => {
    const eventId = this.route.snapshot.parent?.paramMap.get("eventId")!;

    timelines.unshift({
      eventId: eventId
    });

    this.table.initRowEdit(timelines[0]);

    this.isCreating = true;
  }

  save = async (item: Timeline) => {
    if (item?.name?.trim() && item.startDate) {
      if (item.id) {
        this.timelines$ = this.route.parent?.paramMap.pipe(
          switchMap(params => this.timelineService.update(item)),
          switchMap(timeline => this.loadTimelines(item.eventId!)),
        ) || of<Timeline[]>([]);
      }
      else {
        this.timelines$ = this.route.parent?.paramMap.pipe(
          switchMap(params => this.timelineService.add({
            ...item,
            eventId: params.get("eventId")!
          })),
          switchMap(timeline => this.loadTimelines(timeline.eventId!)),
        ) || of<Timeline[]>([]);
      }
    }
  }
}
