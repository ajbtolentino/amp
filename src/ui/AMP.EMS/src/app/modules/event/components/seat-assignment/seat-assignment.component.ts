import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { GuestService, ZoneService } from '@modules/event';
import { Guest, Zone, ZoneSeat } from '@shared/models';
import { Observable, of, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-seat-assignment',
  templateUrl: './seat-assignment.component.html',
  styleUrl: './seat-assignment.component.scss'
})
export class SeatAssignmentComponent implements OnInit {
  guests$: Observable<Guest[]> = new Observable<Guest[]>();
  zones$: Observable<Zone[]> = new Observable<Zone[]>();

  draggedGuest: Guest | undefined | null;
  draggedZoneSeat: ZoneSeat | undefined | null;

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private guestService: GuestService,
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
    return this.eventService.getZones(eventId);
  }

  loadGuests = (eventId: string): Observable<Zone[]> => {
    return this.eventService.guestsWithoutSeats(eventId);
  }

  dragGuestStart = (guest: Guest) => {
    this.draggedGuest = guest;
  }

  dragZoneSeatStart = (zoneSeat: ZoneSeat) => {
    this.draggedZoneSeat = zoneSeat;
  }

  dragGuestEnd() {
    this.draggedGuest = null;
  }

  dragZoneSeatEnd = () => {
    this.draggedZoneSeat = null;
  }

  onUnassignedGuestDropped = (event: any, guests: Guest[], zones: Zone[]) => {
    if (this.draggedZoneSeat?.guest) {
      this.guests$ = of<Guest[]>([...guests, this.draggedZoneSeat.guest]);

      this.removeGuestFromSeat(this.draggedZoneSeat, zones);
    }

    this.draggedGuest = null;
    this.draggedZoneSeat = null;

    this.save(zones);
  }

  removeGuestFromSeat = (zoneSeat: ZoneSeat, zones: Zone[]) => {
    zones.forEach(zone => {
      zone.zoneSeats = zone.zoneSeats?.filter(_ => _.guest?.id !== zoneSeat.guest?.id);
    });

    this.zones$ = of<Zone[]>(zones);
  }

  onZoneDropped(event: any, zone: Zone, unassignedGuests: Guest[], zones: Zone[]): void {
    // Avoid duplicate additions
    if (this.draggedGuest) {
      zone.zoneSeats?.push({
        guestId: this.draggedGuest.id,
        guest: this.draggedGuest!
      });

      this.guests$ = of<Guest[]>(unassignedGuests.filter(_ => _.id !== this.draggedGuest?.id));
    }

    if (this.draggedZoneSeat) {
      this.removeGuestFromSeat(this.draggedZoneSeat, zones);

      zone.zoneSeats?.push({
        guestId: this.draggedZoneSeat.guest?.id,
        guest: this.draggedZoneSeat.guest
      });
    }

    this.draggedGuest = null;
    this.draggedZoneSeat = null;

    this.save(zones);
  }

  save = (zones: Zone[]) => {
    const eventId = this.route.snapshot.parent?.paramMap.get("eventId");
    console.log(eventId)
    this.zones$ = this.zoneService.updateZones(zones)
      .pipe(
        switchMap(() => this.loadZones(eventId!)),
        tap(() => {
          this.guests$ = this.eventService.guestsWithoutSeats(eventId!);
        })
      );
  }
}
