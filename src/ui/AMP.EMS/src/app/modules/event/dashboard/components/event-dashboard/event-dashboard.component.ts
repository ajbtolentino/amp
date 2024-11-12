import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventDashboardService } from '@modules/event/dashboard';
import { PrimeIcons } from 'primeng/api';
import { Observable, switchMap } from 'rxjs';

@Component({
  selector: 'app-event-dashboard',
  templateUrl: './event-dashboard.component.html',
  styles: ``
})
export class EventDashboardComponent implements OnInit {
  chartData: any;

  chartOptions: any;

  guestInvitations$: Observable<any> = new Observable<any>();
  budgets$: Observable<any> = new Observable<any>();
  expenses$: Observable<any> = new Observable<any>();

  events1: any[] = [];

  constructor(private eventDashboardService: EventDashboardService, private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.initChart();
    this.guestInvitations$ = this.route.parent?.paramMap.pipe(switchMap(params => this.eventDashboardService.guestInvitations(params.get('eventId')!)))!;
    this.budgets$ = this.route.parent?.paramMap.pipe(switchMap(params => this.eventDashboardService.budget(params.get('eventId')!)))!;
    this.expenses$ = this.route.parent?.paramMap.pipe(switchMap(params => this.eventDashboardService.expenses(params.get('eventId')!)))!;

    this.events1 = [
      { status: 'Delivered', date: '16/10/2020 10:00', icon: PrimeIcons.CHECK, color: '#607D8B' },
      { status: 'Ordered', date: '15/10/2020 10:30', icon: PrimeIcons.SHOPPING_CART, color: '#9C27B0', },
      { status: 'Processing', date: '15/10/2020 14:00', icon: PrimeIcons.COG, color: '#673AB7' },
      { status: 'Shipped', date: '15/10/2020 16:15', icon: PrimeIcons.ENVELOPE, color: '#FF9800' },
    ];
  }

  initChart() {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
    const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

    this.chartData = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'First Dataset',
          data: [65, 59, 80, 81, 56, 55, 40],
          fill: false,
          backgroundColor: documentStyle.getPropertyValue('--bluegray-700'),
          borderColor: documentStyle.getPropertyValue('--bluegray-700'),
          tension: .4
        },
        {
          label: 'Second Dataset',
          data: [28, 48, 40, 19, 86, 27, 90],
          fill: false,
          backgroundColor: documentStyle.getPropertyValue('--green-600'),
          borderColor: documentStyle.getPropertyValue('--green-600'),
          tension: .4
        }
      ]
    };

    this.chartOptions = {
      plugins: {
        legend: {
          labels: {
            color: textColor
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false
          }
        },
        y: {
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder,
            drawBorder: false
          }
        }
      }
    };
  }
}
