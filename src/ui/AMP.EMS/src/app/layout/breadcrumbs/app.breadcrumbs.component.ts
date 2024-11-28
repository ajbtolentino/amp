import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { filter, map, Observable, startWith } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './app.breadcrumbs.component.html',
})

export class BreadcrumbsComponent implements OnInit {
  static readonly ROUTE_DATA_BREADCRUMB = 'breadcrumb';
  readonly home = { icon: 'pi pi-home', routerLink: ['./'] };
  menuItems$: Observable<MenuItem[]> = new Observable<MenuItem[]>();

  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.menuItems$ = this.router.events
      .pipe(
        filter((e) => e instanceof NavigationEnd),
        startWith(this.router),
        map((e) => this.createBreadcrumbs(this.activatedRoute.root)
        )
      );
  }

  private createBreadcrumbs(route: ActivatedRoute, routerLink: string = '', breadcrumbs: MenuItem[] = []): MenuItem[] {
    const children: ActivatedRoute[] = route.children;

    if (children.length === 0) {
      return breadcrumbs;
    }

    for (const child of children) {
      const routeURL: string = child.snapshot.url.map(segment => segment.path).join('/');
      if (routeURL !== '') {
        routerLink += `/${routeURL}`;
      }

      const label = child.snapshot.data[BreadcrumbsComponent.ROUTE_DATA_BREADCRUMB];

      if (label) {
        breadcrumbs.push({ label, routerLink });
      }

      return this.createBreadcrumbs(child, routerLink, breadcrumbs);
    }
    return []
  }
}
