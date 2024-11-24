import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService, LookupService, VendorService } from '@core/services';
import { EventDashboardService, VendorContractService } from '@modules/event';
import { Guest, GuestInvitation, Timeline, VendorContract, VendorContractPayment } from '@shared/models';
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

  attendees$: Observable<any> = new Observable<any>();
  budgets$: Observable<any> = new Observable<any>();
  expenses$: Observable<any> = new Observable<any>();

  timelines$: Observable<any> = new Observable<any>();

  pieChartOptions: any;

  contractsChart$: Observable<any> = new Observable<any>();

  eventId$: Observable<string> = new Observable<string>();

  constructor(private eventDashboardService: EventDashboardService,
    private eventService: EventService,
    private vendorService: VendorService,
    private vendorContractService: VendorContractService,
    private lookupService: LookupService,
    private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.eventId$ = this.route.parent?.paramMap.pipe(map(params => params.get("eventId") || ''), shareReplay()) || of<string>('');
    this.attendees$ = this.eventId$.pipe(switchMap(eventId => this.eventDashboardService.attendees(eventId)), shareReplay())!;
    this.budgets$ = this.eventId$.pipe(
      switchMap(eventId => this.eventDashboardService.budget(eventId)),
      shareReplay()
    )!;
    this.expenses$ = this.eventId$.pipe(switchMap(eventId => this.eventDashboardService.expenses(eventId)));

    this.initChart();

    this.timelines$ = this.route.parent?.paramMap.pipe(
      switchMap(params => this.eventService.getTimelines(params.get("eventId")!)
        .pipe(
          switchMap(timelines => this.loadContractPayments(params.get("eventId")!).pipe(
            map(paymentTimelines => [...timelines, ...paymentTimelines])
          )),
        )),
      map(timelines => timelines.sort((a, b) => new Date(a.startDate!).getTime() - new Date(b.startDate!).getTime()).map((timeline: any) => ({
        name: timeline.name,
        description: timeline.description,
        date: formatDate(timeline.startDate!, 'medium', 'en-PH'),
        icon: timeline.isPayment ? PrimeIcons.DOLLAR : PrimeIcons.CALENDAR,
        color: timeline.isPayment ? 'green' : '#FF9800'
      })))
    )!;
  }

  mapGuestInvitations = (attendee: any) => {
    return attendee.guestInvitations;
  }

  hasSeats = (guest: Guest): boolean => {
    return (guest?.seats || 0) > 0;
  }

  seatReducer = (acc: any, curr: any) => {
    return acc + curr.seats;
  }

  isGoing = (guestInvitation: GuestInvitation): boolean => {
    if (!guestInvitation?.data) return false;

    return JSON.parse(guestInvitation?.data).response === "ACCEPT";
  }

  goingReducer = (acc: any, guestInvitation: GuestInvitation): boolean => {
    return acc + (JSON.parse(guestInvitation?.data)?.guestNames?.length || 0) + 1;
  }

  guestInvitationReducer = (acc: any, curr: any) => {
    return [...acc, ...curr.guestInvitations];
  }

  hasResponded = (guestInvitation: GuestInvitation): boolean => {
    return guestInvitation?.data;
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

  loadContractPayments = (eventId: string): Observable<Timeline[]> => {
    return this.eventService.getUnreconciledPayments(eventId)
      .pipe(
        switchMap(vendorContractPayments => this.loadVendorContracts(vendorContractPayments)),
        map(vendorContractPayments => vendorContractPayments.map(
          vendorContractPayment => (
            {
              name: `Payment Due`,
              description: `Payment of ${vendorContractPayment.dueAmount} for ${vendorContractPayment.vendorContract?.vendor?.name}`,
              startDate: vendorContractPayment.dueDate,
              isPayment: true
            })
        )
        )
      )
  }

  loadVendorContracts = (vendorContractPayments: VendorContractPayment[]): Observable<VendorContractPayment[]> => {
    return this.vendorContractService.getByIds(vendorContractPayments.map(_ => _.vendorContractId!))
      .pipe(
        switchMap(vendorContracts => this.loadVendors(vendorContracts)),
        map(vendorContracts => vendorContractPayments.map(
          vendorContractPayment => ({
            ...vendorContractPayment,
            vendorContract: vendorContracts.find(_ => _.id === vendorContractPayment.vendorContractId)
          }))
        ));
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
          },
          position: 'left',
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
