import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService, VendorService } from '@core/services';
import { EventDashboardService } from '@modules/event';
import { VendorContract } from '@shared/models';
import { EventVendorTypeBudget } from '@shared/models/event-vendor-type-budget.model';
import { PrimeIcons } from 'primeng/api';
import { map, Observable, of, shareReplay, switchMap } from 'rxjs';

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

  budgetPieData: any;

  pieChartOptions: any;

  contractsChart$: Observable<any> = new Observable<any>();

  eventId$: Observable<string> = new Observable<string>();

  constructor(private eventDashboardService: EventDashboardService,
    private eventService: EventService,
    private vendorService: VendorService,
    private lookupService: LookupService,
    private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.eventId$ = this.route.parent?.paramMap.pipe(map(params => params.get("eventId") || ''), shareReplay()) || of<string>('');
    this.guestInvitations$ = this.eventId$.pipe(switchMap(eventId => this.eventDashboardService.guestInvitations(eventId)), shareReplay())!;
    this.budgets$ = this.eventId$.pipe(
      switchMap(eventId => this.eventDashboardService.budget(eventId)),
      shareReplay()
    )!;
    this.expenses$ = this.eventId$.pipe(switchMap(eventId => this.eventDashboardService.expenses(eventId)));

    this.initChart();

    this.events1 = [
      { status: 'Delivered', date: '16/10/2020 10:00', icon: PrimeIcons.CHECK, color: '#607D8B' },
      { status: 'Ordered', date: '15/10/2020 10:30', icon: PrimeIcons.SHOPPING_CART, color: '#9C27B0', },
      { status: 'Processing', date: '15/10/2020 14:00', icon: PrimeIcons.COG, color: '#673AB7' },
      { status: 'Shipped', date: '15/10/2020 16:15', icon: PrimeIcons.ENVELOPE, color: '#FF9800' },
    ];
  }

  loadVendors = (vendorContracts: VendorContract[]): Observable<VendorContract[]> => {
    return this.vendorService.getByIds(vendorContracts.map(_ => _.vendorId!))
      .pipe(
        switchMap(vendors => this.loadVendorTypes(vendors)),
        map(vendors => vendorContracts.map(vendorContract => ({
          ...vendorContract,
          vendor: vendors.find(_ => _.id === vendorContract.vendorId)
        })))
      );
  }

  loadVendorTypes = (eventVendorTypeBudgets: EventVendorTypeBudget[]): Observable<EventVendorTypeBudget[]> => {
    return this.lookupService.getByIds('vendorType', eventVendorTypeBudgets.map(_ => _.vendorTypeId!))
      .pipe(
        map(vendorTypes => eventVendorTypeBudgets.map(eventVendorTypeBudget => (
          {
            ...eventVendorTypeBudget,
            vendorType: vendorTypes.find(_ => _.id === eventVendorTypeBudget.vendorTypeId)
          }
        )))
      )
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

    this.contractsChart$ = this.eventId$
      .pipe(
        switchMap(eventId =>
          this.eventService.getVendorContracts(eventId).pipe(
            switchMap(vendorContracts => this.loadVendors(vendorContracts)),
            map(vendorContracts => {
              return {
                ...vendorContracts,
                labels: vendorContracts.map(_ => _.vendor?.name),
                datasets: [
                  {
                    data: vendorContracts.map((_: any) => _.amount)
                  }
                ]
              }
            })
          )
        )
      );

    this.pieChartOptions = {
      plugins: {
        tooltip: {
          callbacks: {
            label: (tooltipItem: any) => {
              const value = tooltipItem.raw;
              const total = tooltipItem.dataset.data.reduce((sum: number, v: number) => sum + v, 0);
              const percentage = ((value / total) * 100).toFixed(2);
              return `₱${value.toLocaleString('en-PH', { minimumFractionDigits: 2 })} (${percentage})%`;
            }
          }
        },
        legend: {
          labels: {
            usePointStyle: true,
            color: textColor,
            position: 'bottom'
          }
        }
      },
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
