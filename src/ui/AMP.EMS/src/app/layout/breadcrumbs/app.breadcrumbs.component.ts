import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Data } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Observable } from 'rxjs';
import { BreadcrumbService } from '../../core/services/breadcrumbs.service';

@Injectable({
  providedIn: 'root',
})

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './app.breadcrumbs.component.html',
})

export class BreadcrumbsComponent implements OnInit {
  readonly home = { icon: 'pi pi-home', routerLink: '/' };

  breadcrumbs$: Observable<MenuItem[]> = new Observable<MenuItem[]>();
  routeData$: Observable<Data> = new Observable<Data>();

  constructor(private breadcrumbService: BreadcrumbService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.breadcrumbs$ = this.breadcrumbService.breadcrumbs$;

    this.routeData$ = this.route.data;
  }
}
