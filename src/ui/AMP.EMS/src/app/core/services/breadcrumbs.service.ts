import { Injectable } from "@angular/core";
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
import { MenuItem } from "primeng/api";
import { filter, map, Observable, tap } from "rxjs";

@Injectable({
    providedIn: 'root',
})
export class BreadcrumbService {
    static readonly ROUTE_DATA_BREADCRUMB = 'breadcrumb';

    readonly breadcrumbs$: Observable<MenuItem[]> = new Observable<MenuItem[]>();

    constructor(private router: Router, private activatedRoute: ActivatedRoute) {
        this.breadcrumbs$ = this.router.events.pipe(
            filter(event => event instanceof NavigationEnd),
            tap(() => console.log("!")),
            map(() => this.createBreadcrumbs(this.activatedRoute.root) || [])
        );
    }

    private createBreadcrumbs(route: ActivatedRoute, url: string = '#', breadcrumbs: MenuItem[] = []): MenuItem[] {
        console.log(route);
        const children: ActivatedRoute[] = route.children;

        if (children.length === 0) {
            return breadcrumbs;
        }

        for (const child of children) {
            const routeURL: string = child.snapshot.url.map(segment => segment.path).join('/');
            if (routeURL !== '') {
                url += `/${routeURL}`;
            }

            const label = child.snapshot.data[BreadcrumbService.ROUTE_DATA_BREADCRUMB];
            if (!label) {
                breadcrumbs.push({ label, url });
            }

            return this.createBreadcrumbs(child, url, breadcrumbs);
        }

        return [];
    }
}