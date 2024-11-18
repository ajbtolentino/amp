import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { ZoneService } from '@modules/event/services/zone.service';
import { Zone } from '@shared/models';
import { Table } from 'primeng/table';
import { Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-zone-list',
  templateUrl: './zone-list.component.html',
  styleUrl: './zone-list.component.scss'
})
export class ZoneListComponent implements OnInit {
  zones$: Observable<Zone[]> = new Observable<Zone[]>();

  isCreating: boolean = false;

  @ViewChild('dt') table!: Table;

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private zoneService: ZoneService) {

  }

  ngOnInit(): void {
    this.zones$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadZones(params.get("eventId")!))
    ) || of<Zone[]>([]);
  }

  loadZones = (eventId: string): Observable<Zone[]> => {
    return this.eventService.getZones(eventId);
  }

  addRow = (zones: Zone[]) => {
    const eventId = this.route.snapshot.parent?.paramMap.get("eventId")!;

    zones.unshift({
      eventId: eventId
    });

    this.table.initRowEdit(zones[0]);

    this.isCreating = true;
  }

  save = async (item: Zone) => {
    if (item?.name?.trim()) {
      if (item.id) {
        this.zones$ = this.route.parent?.paramMap.pipe(
          switchMap(params => this.zoneService.update(item)),
          switchMap(zone => this.loadZones(item.eventId!)),
          tap(() => {
            this.isCreating = false;
          })
        ) || of<Zone[]>([]);
      }
      else {
        this.zones$ = this.route.parent?.paramMap.pipe(
          switchMap(params => this.zoneService.add({
            ...item,
            eventId: params.get("eventId")!
          })),
          switchMap(zone => this.loadZones(zone.eventId!)),
          tap(() => {
            this.isCreating = false;
          })
        ) || of<Zone[]>([]);
      }
    }
  }
}
