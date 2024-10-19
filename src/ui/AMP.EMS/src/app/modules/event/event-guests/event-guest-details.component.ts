import { Component, OnInit } from '@angular/core';
import { EventGuest } from '../../../core/models/event-guest';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { GuestService } from '../../../core/services/event-guest.service';

@Component({
  selector: 'app-event-guest-details',
  templateUrl: './event-guest-details.component.html',
  styles: ``
})
export class EventGuestDetailsComponent implements OnInit {
  eventId!: string;

  eventGuest: EventGuest = {
    guest: { firstName: '', lastName: '', nickName: '', phoneNumber: '' },
    event: {}
  };

  loading: boolean = false;

  constructor(private service: GuestService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.parent?.parent?.paramMap.subscribe(data => {
      const eventId = data.get("eventId");

      if (eventId) {
        this.eventId = eventId;
        this.eventGuest.eventId = this.eventId;
      }
    });

    this.route.paramMap.subscribe(data => {
      const eventGuestId = data.get("eventGuestId");

      if (eventGuestId) this.loadEventGuest(eventGuestId);
    });
  }

  loadEventGuest = async (eventGuestId: string) => {
    this.loading = true;

    var response = await this.service.get(eventGuestId);

    if (response?.data) this.eventGuest = response.data;

    this.loading = false;
  }

  save = async () => {
    this.loading = true;

    if (this.eventGuest.guest?.firstName?.trim() && this.eventGuest?.guest?.lastName?.trim()) {

      if (this.eventGuest.id) {
        await this.service.update(this.eventGuest);
      }
      else {
        await this.service.add(this.eventGuest);
      }
    }

    this.loading = false;

    this.router.navigate([`/event/${this.eventId}/guests`]);
  }
}
