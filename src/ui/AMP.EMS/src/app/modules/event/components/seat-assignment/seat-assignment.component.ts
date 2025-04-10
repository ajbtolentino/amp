import { moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@core/services';
import { ZoneService } from '@modules/event';
import { Guest, GuestInvitation, Zone } from '@shared/models';
import { map, Observable, of, shareReplay, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-seat-assignment',
  templateUrl: './seat-assignment.component.html',
  styleUrl: './seat-assignment.component.scss'
})
export class SeatAssignmentComponent implements OnInit {
  guests$: Observable<Guest[]> = new Observable<Guest[]>();
  zones$: Observable<Zone[]> = new Observable<Zone[]>();

  search: string = '';

  constructor(private route: ActivatedRoute,
    private eventService: EventService,
    private zoneService: ZoneService) {

  }

  ngOnInit(): void {
    this.zones$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadZones(params.get("eventId")!))
    ) || of<Zone[]>([]);

    this.guests$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.loadGuests(params.get("eventId")!)),
      shareReplay()
    ) || of<Guest[]>([]);
  }

  loadZones = (eventId: string): Observable<Zone[]> => {
    return this.eventService.getZones(eventId)
      .pipe(
        map(
          zones => {
            zones.map(zone => {
              zone.zoneSeats?.sort((a, b) =>
                a.configuration && b.configuration ? JSON.parse(a.configuration!).position - JSON.parse(b.configuration!).position : 0
              )

              return zone;
            })

            zones.sort((a, b) => a.configuration && b.configuration ? JSON.parse(a.configuration!).position - JSON.parse(b.configuration!).position : 0);

            return zones;
          }
        ),
      );
  }

  loadGuests = (eventId: string): Observable<Guest[]> => {
    return this.eventService.unseatedGuests(eventId);
  }

  mapZoneIds = (zone: Zone) => {
    return zone.id!;
  }

  zoneSeatReducer = (acc: any, curr: any) => {
    if (!curr.guest.guestInvitations.length) return acc + 1;

    const acceptedInvitations = curr.guest.guestInvitations.filter((g: any) => g.data && JSON.parse(g.data)?.response === 'ACCEPT')
      .reduce((a: any, c: any) => a + (JSON.parse(c.data).guestNames?.length || 0), 0)

    return acc + acceptedInvitations + 1;
  }

  disableAttendeeDrop = () => {
    return false;
  }

  isGoing = (guestInvitation: GuestInvitation) => {
    if (!guestInvitation.data) return false;

    return JSON.parse(guestInvitation.data).response === 'ACCEPT';
  }

  filterAttendees = () => {
    this.guests$ = this.guests$.pipe(
      map((guests) => guests.filter(
        guest => `${guest.salutation?.toLowerCase()}${guest.firstName?.toLowerCase()}${guest.middleName?.toLowerCase()}${guest.lastName?.toLowerCase()}${guest.suffix?.toLowerCase()}`.includes(this.search.toLowerCase())
      ))
    )
    // return 
  }

  seatAttendee(event: any, zone: Zone, zones: Zone[]): void {
    //Transfer to zone
    if (event.container != event.previousContainer) {
      transferArrayItem(
        event.previousContainer.data,
        zone.zoneSeats!,
        event.previousIndex,
        event.currentIndex,
      );

      zone.zoneSeats = zone.zoneSeats!.map((zoneSeat: any, index: any) => ({
        zoneId: zone.id,
        guestId: zoneSeat.guestId ?? event.item.data.id,
        configuration: JSON.stringify({
          position: index
        })
      }));

      this.save(zones);
    }

    //Re-arrange
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

    //Remove from zone
    if (!event.isPointerOverContainer) {
      zones.forEach(zone => {
        zone.zoneSeats = zone.zoneSeats?.filter(_ => _.guest?.id !== event.item.data.id);
      });

      this.save(zones);
    }
  }

  attendeeReducer = (acc: any, curr: any) => {
    if (!curr.data) return acc;
    return [...acc, ...(JSON.parse(curr.data)?.guestNames || [])];
  }

  reOrderZone = (event: any, zones: Zone[]) => {
    if (event.previousIndex != event.currentIndex) {
      moveItemInArray(zones, event.previousIndex, event.currentIndex);

      zones = zones.map((zone, index) => ({
        ...zone,
        configuration: JSON.stringify({
          position: index
        })
      }));

      this.save(zones);
    }
  }

  save = (zones: Zone[]) => {
    const eventId = this.route.snapshot.parent?.paramMap.get("eventId");
    this.zones$ = this.zoneService.updateZones(zones)
      .pipe(
        switchMap(() => this.loadZones(eventId!)),
        tap(() => {
          this.guests$ = this.eventService.unseatedGuests(eventId!);
        })
      );
  }
}
