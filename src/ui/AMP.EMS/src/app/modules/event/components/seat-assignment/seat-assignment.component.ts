import { moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { ZoneService } from '@modules/event';
import { Guest, Zone } from '@shared/models';
import { map, Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-seat-assignment',
  templateUrl: './seat-assignment.component.html',
  styleUrl: './seat-assignment.component.scss'
})
export class SeatAssignmentComponent implements OnInit {
  guests$: Observable<Guest[]> = new Observable<Guest[]>();
  zones$: Observable<Zone[]> = new Observable<Zone[]>();

  draggedGuest: Guest | undefined | null;

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private zoneService: ZoneService) {

  }

  ngOnInit(): void {
    this.zones$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadZones(params.get("eventId")!))
    ) || of<Zone[]>([]);

    this.guests$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadGuests(params.get("eventId")!))
    ) || of<Guest[]>([]);
  }


  loadZones = (eventId: string): Observable<Zone[]> => {
    return this.eventService.getZones(eventId)
      .pipe(
        map(
          zones => zones.map(zone => {
            zone.zoneSeats?.sort((a, b) =>
              a.configuration && b.configuration ? JSON.parse(a.configuration!).position - JSON.parse(b.configuration!).position : 0
            )

            return zone;
          })
        ),
      );
  }

  loadGuests = (eventId: string): Observable<Zone[]> => {
    return this.eventService.guestsWithoutSeats(eventId);
  }

  dragGuestStart = (guest: Guest) => {
    this.draggedGuest = guest;
  }

  dragGuestEnd() {
    this.draggedGuest = null;
  }

  onUnassignedGuestDropped = (event: any, zones: Zone[]) => {
    if (this.draggedGuest) {
      this.removeGuestFromSeat(this.draggedGuest!, zones);
      this.save(zones);
    }

    this.draggedGuest = null;
  }

  removeGuestFromSeat = (guest: Guest, zones: Zone[]) => {
    zones.forEach(zone => {
      zone.zoneSeats = zone.zoneSeats?.filter(_ => _.guest?.id !== guest.id);
    });
  }

  onZoneDropped(event: any, zone: Zone, zones: Zone[]): void {
    if (this.draggedGuest && event.container != event.previousContainer) {
      this.removeGuestFromSeat(this.draggedGuest, zones);

      zone.zoneSeats?.push({
        zoneId: zone.id,
        guestId: this.draggedGuest.id,
        guest: this.draggedGuest!,
        configuration: JSON.stringify({
          position: event.currentIndex
        })
      });

      this.save(zones);
    }

    if ((zone?.zoneSeats && event.container == event.previousContainer) &&
      event.previousIndex != event.currentIndex) {
      moveItemInArray(zone.zoneSeats!, event.previousIndex, event.currentIndex);

      zone.zoneSeats = zone.zoneSeats.map((zoneSeat: any, index: any) => ({
        zoneId: zone.id,
        guestId: zoneSeat.guestId,
        guest: zoneSeat.guest,
        configuration: JSON.stringify({
          position: index
        })
      }));

      this.save(zones);
    }

    if (!event.isPointerOverContainer && this.draggedGuest) {
      this.removeGuestFromSeat(this.draggedGuest, zones);
      this.save(zones);
    }

    this.draggedGuest = null;
  }

  reOrder = (event: any) => {
    console.log(event)
  }

  save = (zones: Zone[]) => {
    const eventId = this.route.snapshot.parent?.paramMap.get("eventId");
    this.zones$ = this.zoneService.updateZones(zones)
      .pipe(
        switchMap(() => this.loadZones(eventId!)),
        tap(() => {
          this.guests$ = this.eventService.guestsWithoutSeats(eventId!);
        })
      );
  }
}
