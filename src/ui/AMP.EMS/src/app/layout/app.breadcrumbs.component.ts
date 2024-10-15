import { Component, Injectable, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { BreadcrumbService } from '../core/services/breadcrumbs.service';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './app.breadcrumbs.component.html',
})

export class AppBreadcrumbsComponent implements OnInit {
  readonly home = { icon: 'pi pi-home', routerLink: '/' };

  breadcrumbs: MenuItem[] = [];

  constructor(private breadcrumbService: BreadcrumbService, private router: Router) { }

  ngOnInit(): void {
    this.breadcrumbService.breadcrumbs$.subscribe(s => this.breadcrumbs = s);
  }
}
